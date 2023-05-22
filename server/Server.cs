using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Media;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;

namespace ServerProgram
{
    internal class Server
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private int room;
        private IPAddress serverIP;
        public IPAddress clientIP;
        private int port;
        private int win_point;
        private int remain_qs=5;

        public int Port { get { return port; } }

        public string username = "NONE";
        public bool ready = false;
        
        public Server(IPAddress serverIP, IPAddress clientIP, int port, int room) 
        { //서버 생성자. 클라스 생성과 함께 서버연결
            this.port = port;
            this.room = room;
            this.serverIP = serverIP;
            this.clientIP = clientIP;
            this.listener = new TcpListener(serverIP, port);
        }
        ~Server()
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=login_info.db");
            conn.Open();
            string query = "update idpw set wins = "+win_point+" where ID= '"+username+"'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            
        }

        public void change_room(int newRoom)
        {
            room = newRoom;
        }
        public void run_server() //서버 스트림 생성(스레드 내에서 실행)
        {
            listener.Start();
            this.client = listener.AcceptTcpClient();
            this.reader = new StreamReader(this.client.GetStream());
            this.writer = new StreamWriter(this.client.GetStream());
            this.writer.AutoFlush = true;
        }
        public string read_client() //client에서 메세지 받아옴 
        {
            string msg = this.reader.ReadLine();
            Console.WriteLine(msg); // console 작성 형태, 수정하여 사용, Invoke 필요 예상
            return msg;
        }

        // room 번호와 관계없이 클라이언트에 메세지 전송.
        public void SendClient(string msg)
        {
            writer.WriteLine(msg);
        }

        //SendClient 대신에 이걸 앞으로 써야할듯. | 붙이기 귀찮으니까
        public void SendResponse(string header, string content)
        {
            writer.WriteLine(header + "|" + content);
        }

        public void write_client(int room, string msg) // room 번호가 같으면 클라이언트에 메세지 전송 
        {
            if (this.room == room)
            {
                this.writer.WriteLine(msg);
            }
        }
        public int roomnum() { return this.room; }
        public void win() { win_point++; } //이겼을 때 호출, 점수 부여
        public void win(int n) { win_point += n; }
        public void set_winpoint(int winpoint) { win_point = winpoint; }
        public void minus_chance() { remain_qs--; }
        public int get_remain_chance() { return remain_qs; }
        public void set_remain_chance() { remain_qs = 5; }
    }

    public class MainServer
    {
        #region 통신 기능
        private List<Server> servers = new List<Server>();
        private ServerForm parentForm;

        private const int portmain = 5000; //기본(로비)포트
        private int portCount = 1;
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1"); // ip는 입력 받아 저장

        public int NewPort() { return portmain + portCount++; }

        public MainServer(ServerForm parentForm)
        {
            this.parentForm = parentForm;

            //서버 아이피 저장 및 로그로 출력
            string myIPString = GetMyIP();
            serverIP = IPAddress.Parse(myIPString);

            parentForm.PrintLog("Server IP : " + myIPString);
        }

        public void server_start()//lobby server를 시작. 한 번만 호출
        {
            Thread thread1 = new Thread(lobby_server);
            thread1.IsBackground = true;
            thread1.Start();

            LoadLoginData();
        }
        void msg_return(int room, string msg) // 보유한 서버에 대해 메세지 전달(방 번호 다르면 잘림)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                servers[i].write_client(room, msg);
            }
        }

        void lobby_server()//스레드 내에서 새로운 클라이언트를 대기, 클라이언트가 접속하면 새 포트와 방 번호를 할당
        {
            try
            {
                while (true)
                {
                    TcpListener listener = new TcpListener(IPAddress.Any, portmain);
                    listener.Start();

                    //클라이언트의 IP 주소를 받음. 딱히 사용하지는 않고 로그 출력할 때만 사용됨
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader sread = new StreamReader(client.GetStream());
                    string msg = sread.ReadLine();
                    //int room = int.Parse(msg); //방번호 받고 포트번호 주기 -> 이재 방 번호는 필요없음. 0으로 고정
                    sread.Close();
                    client.Close();

                    int newPort = NewPort();

                    TcpClient client2 = listener.AcceptTcpClient();
                    StreamWriter swrite = new StreamWriter(client2.GetStream());
                    swrite.WriteLine(newPort);
                    swrite.Close();
                    client2.Close();
                    listener.Stop();

                    IPAddress clientIP = IPAddress.Parse("127.0.0.1");

                    servers.Add(new Server(msg.Equals("127.0.0.1") ? clientIP : serverIP, clientIP, newPort, 0));
                    Thread thread1 = new Thread(chat_server);
                    thread1.IsBackground = true;
                    thread1.Start();

                    parentForm.PrintLog("new clent connected ip : " + msg + " | port : " + newPort + " | room : " + 0);
                }
            }catch(Exception e)
            {
                parentForm.PrintLog(e.Message);
            }
        }

        //클라이언트에서 보내는 요청들을 처리하는 부분
        void chat_server()//client에 대응하는 스레드, 메세지 대기 
        {
            Server server = servers[servers.Count - 1];
            server.run_server();

            try
            {
                while (true)//client 메세지 수신
                {
                    string msg = server.read_client();
                    string[] request = msg.Split('|');
                    string header, content;
                    if(request.Length < 2)
                    {
                        header = "NONE";
                        content = msg;
                    }
                    else
                    {
                        header = request[0];
                        content = request[1];
                    }

                    //일반 메세지
                    if (header.Equals("NONE"))
                    {
                        msg_return(server.roomnum(), header + "|" + content);
                    }
                    //방 번호 관련
                    else if (header.Equals("GETROOM"))
                    {
                        server.SendClient("GETROOM|" + server.roomnum());
                    } else if (header.Equals("SETROOM")) {
                        int newRoom = 0;

                        if (int.TryParse(content, out newRoom))
                        {
                            server.change_room(newRoom);
                            parentForm.PrintLog("changed room | port : " + server.Port + " | " + content);
                            server.SendClient("GETROOM|" + server.roomnum());
                        }
                    }
                    //로그인 관련
                    else if (header.Equals("SIGNIN"))
                    {
                        string[] idpw = content.Split(':');
                        SignIn(idpw[0], idpw[1], server);

                    } else if (header.Equals("SIGNUP"))
                    {
                        string[] idpw = content.Split(':');
                        SignUp(idpw[0], idpw[1], server);
                    }
                    //방 관련
                    else if (header.Equals("ROOMLIST"))
                    {
                        server.SendClient("ROOMLIST|" + GetRoomListString());
                    } else if (header.Equals("ROOMCREATE"))
                    {
                        string[] roomInfo = content.Split(',');
                        if (RoomCreate(roomInfo[0], int.Parse(roomInfo[1]), server))
                        {
                            server.SendClient("ROOMCREATE|1");
                            //방장 화면으로 세팅
                            server.SendResponse("GAMESCREEN", "OWNERWAIT");
                        } else
                        {
                            server.SendClient("ROOMCREATE|0");
                        }
                    }
                    else if (header.Equals("ROOMJOIN"))
                    {
                        RoomJoin(content, server);
                    } else if (header.Equals("ROOMOUT"))
                    {
                        RoomOut(content, server);
                    }
                    //방 채팅
                    else if (header.Equals("ROOMCHAT"))
                    {
                        RoomChat(content, server);
                    }
                    else if (header.Equals("PLAYERLIST"))
                    {
                        PlayerList(content, server);
                    }
                    //게임 진행
                    else if (header.Equals("GAMESTART"))
                    {
                        GameStart(server);
                    } else if (header.Equals("WORDSELECT"))
                    {
                        WordSelect(content, server);
                    } else if (header.Equals("SENDANSWER"))
                    {
                        SendAnswer(content, server);

                    }else if (header.Equals("SENDQUESTION"))
                    {
                        SendQuestion(content, server);
                    }
                    else if (header.Equals("GAMEREADY"))
                    {
                        GameReady(server);
                    }
                    else if (header.Equals("READYLIST"))
                    {
                        ReadyList(content, server);
                    }
                    else if (header.Equals("GUESSANSWER"))
                    {
                        GuessAnswer(content,server);
                    }
                    else if (header.Equals("BUZZER"))
                    {
                        Buzzer(server);
                    }
                    //알 수 없는 header일때
                    else
                    {
                        msg_return(server.roomnum(), header + "|" + content);
                    }
                }
            }
            catch
            {
                parentForm.PrintLog("disconnect client | ip : " + server.clientIP.ToString() + 
                    " | port : " + server.Port.ToString() + " | room : " + server.roomnum().ToString());
                servers.Remove(server);
            }
        }

        //실행하는 컴퓨터의 ip 주소를 반환
        private string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myIP = string.Empty;
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = host.AddressList[i].ToString();
                    break;
                }
            }

            return myIP;
        }

        #endregion

        #region 로그인 기능

        private Dictionary<string, string> loginData = new Dictionary<string, string>();
        private Dictionary<string, int> win_points= new Dictionary<string, int>();
        private SQLiteConnection conn;
        private void LoadLoginData()
        {
            //파일에서 아이디-패스워드 데이터 읽어오기. 
            if (!System.IO.File.Exists("login_info.db"))
                SQLiteConnection.CreateFile("login_info.db");
            conn = new SQLiteConnection("Data Source=login_info.db");
            conn.Open();
            string query = "create table if not exists idpw (ID varchar(20), pw varchar(20)" +
                ", wins numeric(5,0), primary key (ID))";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            int result = cmd.ExecuteNonQuery();

            query = "select * from idpw";
            cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                loginData.Add(reader["ID"].ToString(), reader["pw"].ToString());
                win_points.Add(reader["ID"].ToString(),Convert.ToInt32(reader["wins"]));
            }
            reader.Close();

        }

        private void SignIn(string username, string password, Server server)
        {
            if (loginData.ContainsKey(username))
            {
                if (loginData[username].Equals(password))
                {
                    parentForm.PrintLog("login user : " + username + ", " + password);
                    server.SendClient("SIGNIN|" + username);
                    server.username = username;
                    int win;
                    win_points.TryGetValue(username, out win);
                    server.set_winpoint(win);
                    return;
                }
            }

            server.SendClient("SIGNIN|");
        }

        private void SignUp(string username, string password, Server server)
        {
            if (loginData.ContainsKey(username))
            {
                server.SendClient("SIGNUP|0");
            }
            else
            {
                parentForm.PrintLog("create new account : " + username + ", " + password);
                loginData.Add(username, password);
                win_points.Add(username, 0);

                conn = new SQLiteConnection("Data Source=login_info.db");
                conn.Open();
                string query = "insert into idpw (ID,pw,wins) values ('" +
                    username + "','" + password + "','0')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

                server.SendClient("SIGNUP|1");
            }
        }
        #endregion

        #region 방 관리
        private List<GameRoom> gameRooms = new List<GameRoom>();
        private bool RoomCreate(string roomName, int max, Server roomOwner)
        {
            for(int i=0; i<gameRooms.Count; i++)
            {
                if (gameRooms[i].name == roomName) return false;
            }

            roomOwner.ready = true;
            GameRoom newGameRoom = new GameRoom(roomName, max);
            newGameRoom.AddPlayer(roomOwner);
            newGameRoom.ownerPlayer = roomOwner;
            gameRooms.Add(newGameRoom);

            PlayerList(roomName, roomOwner);
            
            return true;
        }

        private void RoomJoin(string roomName, Server server)
        {
            int index = -1;

            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].name.Equals(roomName))
                {
                    if (gameRooms[i].Max())
                    {
                        index = -2;
                        break;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index == -1)
            {
                server.SendClient("ROOMJOIN|-1");
            }
            else if (index == -2)
            {
                server.SendClient("ROOMJOIN|-2");
            }
            else
            {
                server.ready = false;
                //기존에 방에 있던 플레이어들에게 해당 플레이어가 들어와서 생긴 방의 변동을 자동으로 전달
                gameRooms[index].AddPlayer(server);
                gameRooms[index].players.ForEach(p => PlayerList(gameRooms[index].name, p));
                server.SendClient("ROOMJOIN|" + gameRooms[index].name);

                //일반 플레이어 화면으로 세팅 이거 근데 순서 꼬이면 어떡하지? 한번 해보고 문제 있으면 ROOMJOIN시 인자로 보내서 그때 같이 처리하는걸로
                server.SendResponse("GAMESCREEN", "PLAYERWAIT");
            }
        }

        private void RoomOut(string num, Server server)
        {
            server.win(int.Parse(num));
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    //게임중엔 못 나감
                    if (gameRooms[i].starting) return;

                    gameRooms[i].RemovePlayer(server);
                    if (gameRooms[i].players.Count == 0)
                    {
                        gameRooms.RemoveAt(i);
                    }
                    else
                    {
                        //남아있는 플레이어들에게 해당 플레이어가 나가서 생긴 방의 변동을 자동으로 전달
                        gameRooms[i].players.ForEach(p => PlayerList(gameRooms[i].name, p));
                    }

                    server.change_room(0);
                    server.SendClient("ROOMOUT|0");

                    return;
                }
            }
        }

        private string GetRoomListString()
        {
            string roomListString = string.Empty;

            if (gameRooms.Count == 0) return roomListString;

            foreach (GameRoom gameRoom in gameRooms)
            {
                roomListString += string.Format("{0},{1},{2}:", gameRoom.name, gameRoom.players.Count, gameRoom.max);
            }

            return roomListString.Substring(0, roomListString.Length - 1);
            
        }

        private void PlayerList(string roomName, Server server)
        {
            GameRoom room = gameRooms.Find(r => r.name == roomName);
            string playerListString = string.Empty;
            if (room != null)
            {
                room.players.ForEach(p => playerListString += p.username + ",");

                if (playerListString.Length > 0) playerListString = playerListString.Substring(0, playerListString.Length - 1);
            }

            server.SendClient("PLAYERLIST|" + playerListString);
        }

        private void ReadyList(string roomName, Server server)
        {
            GameRoom room = gameRooms.Find(r => r.name == roomName);
            string readyListString = string.Empty;
            if (room != null)
            {
                room.players.ForEach(p =>
                {
                    if (p.ready) readyListString += p.username + ",";
                });

                if (readyListString.Length > 0) readyListString = readyListString.Substring(0, readyListString.Length - 1);
            }

            server.SendClient("READYLIST|" + readyListString);
        }
        #endregion

        #region 채팅 기능
        private void RoomChat(string content, Server server)
        {
            GameRoom gameRoom = null;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    gameRoom = gameRooms[i];
                    break;
                }
            }

            if (gameRoom == null) return;

            string chatListString = string.Empty;

            gameRoom.chats.Add(content);
            gameRoom.chats.ForEach(chat =>
            {
                chatListString = chatListString + "," + chat;
            });

            chatListString = chatListString.Substring(1, chatListString.Length - 1);

            gameRoom.players.ForEach(p =>
            {
                p.SendClient("ROOMCHAT|" + chatListString);
            });
        }


        #endregion

        #region 게임 진행
        private void GameStart(Server server)
        {
            GameRoom room = gameRooms.Find(r => r.ContainPlayer(server));
            room.GameStart();
        }

        private void GameReady(Server server)
        {
            server.ready = !server.ready;
            server.SendResponse("GAMEREADY", server.ready ? "1" : "0");

            gameRooms.ForEach(r =>
            {
                if (r.ContainPlayer(server))
                {
                    r.players.ForEach(p => ReadyList(r.name, p));
                    return;
                }
            });
        }

        private void WordSelect(string word, Server server)
        {
            GameRoom room = null;
            for(int i=0; i<gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    room = gameRooms[i];
                    break;
                }
            }

            if(room == null) return;

            room.word = word;

            room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWAIT");
            List<Server> questionerList = room.GetQuestionerList();
            int currentQuestioner = room.CurrentQuestioner;

            for(int i=0; i < questionerList.Count; i++)
            {
                if(i == currentQuestioner)
                {
                    //첫번째 질문자
                    questionerList[i].SendResponse("GAMESCREEN", "QUESTIONERQUESTION");
                }
                else
                {
                    //나머지는 대기
                    questionerList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                }
            }
        }

        private void SendAnswer(string answer, Server server)
        {
            RoomChat(answer, server);
            
            GameRoom room = null;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    room = gameRooms[i];
                    break;
                }
            }

            if (room == null) return;
  
            room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWAIT");
            int questioner = room.NextQuestioner();

            List<Server> qList = room.GetQuestionerList();
            if (room.Get_total_q() != 20)
            {
                for (int i = 0; i < qList.Count; i++)
                {
                    if (i == questioner)
                    {
                        qList[i].SendResponse("GAMESCREEN", "QUESTIONERQUESTION");
                    }
                    else
                    {
                        qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                    }
                }
            }
            else
            {
                for (int i = 0; i < qList.Count; i++)
                {
                    qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                }
            }
        }

        private void SendQuestion(string question, Server server)
        {
            GameRoom room = null;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    room = gameRooms[i];
                    break;
                }
            }
            if (room == null) return;
            room.Plus_total_q();
            RoomChat(room.Get_total_q().ToString() + "번째 질문 : " + question, server);
            //출제자만 채팅 활성화
            room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWANSWER");
            int questioner = room.CurrentQuestioner;
            

            List<Server> qList = room.GetQuestionerList();

            for (int i = 0; i < qList.Count; i++)
            {
                qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
            }
        }

        private void GuessAnswer(string guess,Server server)
        {
            RoomChat(guess, server);
            GameRoom room = null;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    room = gameRooms[i];
                    break;
                }
            }
            if (room == null) return;
            if (room.word.CompareTo(guess) == 0)
            {
                server.win(); //점수추가
                RoomChat("정답!", server);
                room.NextPresenter();
                List<Server> qList = room.GetQuestionerList();
                if (room.CurrentQuestioner != 0)
                {//출제자 한바퀴만
                    for (int i = 0; i < qList.Count; i++)
                    {
                        if (qList[i].username.CompareTo(room.GetPresenter().username) == 0)//다음 문제
                        {
                            qList[i].SendResponse("GAMESCREEN", "PRESENTERCHOICE");
                        }
                        else
                        {
                            qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                        }
                    }
                }
                else //대기방으로
                {
                    RoomChat("게임 종료!", server);
                    room.starting = false; 
                    for (int i = 0; i < qList.Count; i++)
                    {
                        if (server.username.CompareTo(room.GetOwner().username)==0)
                        {
                            qList[i].SendResponse("GAMESCREEN", "OWNERWAIT");
                        }
                        else
                        {
                            qList[i].SendResponse("GAMESCREEN", "PLAYERWAIT");
                        }
                    }
                }
            }
            else
            {
                room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWAIT");
                int questioner = room.CurrentQuestioner;

                List<Server> qList = room.GetQuestionerList();

                for (int i = 0; i < qList.Count; i++)
                {
                    if (server.username.CompareTo(room.GetOwner().username) == 0)
                    {
                        qList[i].SendResponse("GAMESCREEN", "QUESTIONERQUESTION");
                    }
                    else
                    {
                        qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                    }
                }
            }
            int q = room.CurrentQuestioner;
            int tok;
            List<Server> ql = room.GetQuestionerList();

            for (tok = 0; tok < q; tok++)
            {
                if (ql[tok].get_remain_chance() != 0)
                    break;
            }
            if (tok == q) // 모든 플레이어가 도전 기회를 소모해서 게임 종료하는 조건 
            {
                RoomChat("실패! 정답은 "+room.word, server);
                room.NextPresenter();
                List<Server> qList = room.GetQuestionerList();
                if (room.CurrentQuestioner != 0)
                {//출제자 한바퀴만
                    for (int i = 0; i < qList.Count; i++)
                    {
                        if (qList[i].username.CompareTo(room.GetPresenter().username)==0)//다음 문제
                        {
                            qList[i].SendResponse("GAMESCREEN", "PRESENTERCHOICE");
                        }
                        else
                        {
                            qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                        }
                    }
                }
                else //대기방으로
                {
                    RoomChat("게임 종료!", server);
                    room.starting = false;
                    for (int i = 0; i < qList.Count; i++)
                    {
                        if (server.username.CompareTo(room.GetOwner().username) == 0)
                        {
                            qList[i].SendResponse("GAMESCREEN", "OWNERWAIT");
                        }
                        else
                        {
                            qList[i].SendResponse("GAMESCREEN", "PLAYERWAIT");
                        }
                    }
                }
            }

        }
        private void Buzzer(Server server)
        {
            server.minus_chance();
            RoomChat(server.username + " 정답 시도중", server);
            GameRoom room = null;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    room = gameRooms[i];
                    break;
                }
            }

            if (room == null) return;

            room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWAIT");
            int questioner = room.CurrentQuestioner;

            List<Server> qList = room.GetQuestionerList();

            for (int i = 0; i < qList.Count; i++)
            {
                if (server.username.CompareTo(room.GetOwner().username) == 0)
                {
                    qList[i].SendResponse("GAMESCREEN", "QUESTIONERQUESTION");
                }
                else
                {
                    qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                }
            }
        }
        #endregion
    }

    //방 정보를 담고있음.
    internal class GameRoom
    {
        public string name;
        public int max;
        public int room;
        public List<Server> players;
        public Server ownerPlayer;
        public bool starting = false;
        public List<string> chats;
        private int presenter = 0;
        private int currentQuestioner = 0;
        private int total_questions = 0;
        public int CurrentQuestioner { get { return currentQuestioner; } }
        public string word;

        //owner가 시작 요청을 보낼 경우 보내게 될 응답. 게임 시작 신호를 모든 플레이어에게 보낸다.
        public void GameStart()
        {
            if(players.Count > 1)
            {
                for(int i=0; i < players.Count; i++)
                {
                    if (players[i].ready == false)
                    {
                        ownerPlayer.SendResponse("GAMESTART", "0");
                    }
                    players[i].set_remain_chance();
                }
                starting = true;

                //채팅 초기화
                ClearChat();

                //첫번째 사람에게 가장 첫 출제자 권한 부여
                players[0].SendResponse("GAMESCREEN", "PRESENTERCHOICE");
                presenter = 0;

                //나머지 플레이어들에게
                for(int i=1; i<players.Count; i++)
                {
                    players[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                }
            }
        }
        
        public int NextQuestioner()
        {
            List<Server> questionerList = GetQuestionerList();
            currentQuestioner++;
            if (questionerList.Count == currentQuestioner) currentQuestioner = 0;

            return currentQuestioner;
        }

        public bool Max() => players.Count == max;

        public bool ContainPlayer(Server player)
        {
            return players.Contains(player);
        }

        public GameRoom(string name, int max)
        {
            this.name = name;
            this.max = max;
            this.room = NextRoom();
            players = new List<Server>();
            chats = new List<string>();
        }

        public void ClearChat()
        {
            chats.Clear();

            players.ForEach(p =>
            {
                p.SendResponse("ROOMCHAT|", string.Empty);
            });
        }

        public void AddChat(string name, string content)
        {
            chats.Add(name + ":" + content);
        }

        public bool AddPlayer(Server server)
        {
            if (players.Count == max) return false;
            players.Add(server);
            server.change_room(room);
            return true;
        }

        public void RemovePlayer(Server player)
        {
            players.Remove(player);
            if(players.Count > 0)
            {
                if(ownerPlayer == player)
                {
                    ownerPlayer = players[0];
                   
                    ownerPlayer.SendResponse("GAMESCREEN", "OWNERWAIT");
                }
            }
        }

        public Server GetPresenter()
        {
            return players[presenter];
        }
        public void NextPresenter() { presenter++; }
        public Server GetOwner()
        {
            return ownerPlayer;
        }
        public List<Server> GetQuestionerList()
        {
            List<Server> questionerList = new List<Server>();

            for (int i = 0; i < players.Count; i++)
            {
                if(i != presenter) questionerList.Add(players[i]);
            }
            return questionerList;
        }
        public int Get_total_q() { return total_questions; }
        public void Plus_total_q() { total_questions++; }
        private static int roomCount = 1;
        private static int NextRoom() { return roomCount++; }
    }
}
