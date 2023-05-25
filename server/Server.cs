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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ServerProgram
{
    internal class Server
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private int room;
        public IPAddress clientIP;
        private int win_point;
        private int remain_qs=5;

        public string username = "NONE";
        public bool ready = false;
        
        public Server(IPAddress clientIP, TcpListener l, int room,TcpClient client, StreamReader reader) 
        { //서버 생성자. 클라스 생성과 함께 서버연결
            this.room = room;
            this.clientIP = clientIP;
            this.listener = l;
            this.reader = reader;
            this.client = client;
        }
        ~Server()
        {
            update_db();
        }

        public void update_db()
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=login_info.db");
            conn.Open();
            string query = "select wins from idpw where ID='" + username + "'";
            SQLiteCommand cmd= new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            int result=0;
            while (dr.Read())
            {
                result = Convert.ToInt32(dr["wins"]);
            }
            query= "update idpw set wins = " + (result+win_point) + " where ID= '" + username + "'";
            cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            win_point = 0;
        }

        public void change_room(int newRoom)
        {
            room = newRoom;
        }
        public void run_server() //서버 스트림 생성(스레드 내에서 실행)
        {
            listener.Start();
         
           
            this.writer = new StreamWriter(this.client.GetStream());
            this.writer.AutoFlush = true;
        }
        public string read_client() //client에서 메세지 받아옴 
        {
            string msg = this.reader.ReadLine();
            Console.WriteLine(msg); // console 작성 형태, 수정하여 사용, Invoke 필요 예상
            return msg;
        }

        //클라이언트에 메세지 전송
        public void SendResponse(string header, string content)
        {
            writer.WriteLine(header + "|" + content);
        }

        public void SendResponse(string header, int value)
        {
            writer.WriteLine(header + "|" + value.ToString());
        }

        public int roomnum() { return this.room; }
        public void win() { win_point++; } //이겼을 때 호출, 점수 부여
        public void win(int n) { win_point += n; }
        public void set_winpoint(int winpoint) { win_point = winpoint; }
        public int get_winpoint() { return win_point; }
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
            LoadFriendData();
        }

        void lobby_server()//스레드 내에서 새로운 클라이언트를 대기, 클라이언트가 접속하면 새 포트와 방 번호를 할당
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, portmain);
                listener.Start();
                while (true)
                {
                    //클라이언트의 IP 주소를 받음. 딱히 사용하지는 않고 로그 출력할 때만 사용됨
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader sread = new StreamReader(client.GetStream());
                    string msg = sread.ReadLine();

                    IPAddress clientIP = IPAddress.Parse("127.0.0.1");

                    servers.Add(new Server(clientIP, listener, 0, client, sread));
                    Thread thread1 = new Thread(chat_server);
                    thread1.IsBackground = true;
                    thread1.Start();

                    parentForm.PrintLog("new clent connected ip : " + msg + " | port : " + portmain + " | room : " + 0);
                }
            } catch (Exception e)
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
                    if (request.Length < 2)
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
                        server.SendResponse(header, content);
                    }
                    //방 번호 관련
                    else if (header.Equals("GETROOM"))
                    {
                        server.SendResponse("GETROOM", server.roomnum());
                    } else if (header.Equals("SETROOM")) {
                        int newRoom = 0;

                        if (int.TryParse(content, out newRoom))
                        {
                            server.change_room(newRoom);
                            parentForm.PrintLog("changed room |" + content);
                            server.SendResponse("GETROOM", server.roomnum());
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
                    } else if (header.Equals("SIGNOUT"))
                    {
                        SignOut(server);
                    }
                    //방 관련
                    else if (header.Equals("ROOMLIST"))
                    {
                        server.SendResponse("ROOMLIST", GetRoomListString());
                    } else if (header.Equals("ROOMCREATE"))
                    {
                        string[] roomInfo = content.Split(',');
                        if (RoomCreate(roomInfo[0], int.Parse(roomInfo[1]), server))
                        {
                            RefreshRoom();
                            server.SendResponse("ROOMCREATE", 1);
                            //방장 화면으로 세팅
                            server.SendResponse("GAMESCREEN", "OWNERWAIT");
                        } else
                        {
                            server.SendResponse("ROOMCREATE", 0);
                        }
                    }
                    else if (header.Equals("ROOMJOIN"))
                    {
                        RoomJoin(content, server);
                    } else if (header.Equals("ROOMOUT"))
                    {
                        RoomOut(content, server);
                    }
                    //친구
                    else if (header.Equals("JOINFRIENDROOM"))
                    {
                        JoinUserGameRoom(content, server);
                    }
                    else if (header.Equals("ACCEPTFRIEND"))
                    {
                        Server server1 = FindServer(server.username);
                        Server server2 = FindServer(content);
                        if (AddFriendShip(server1, server2)==true)
                        {
                            server1.SendResponse("ACCEPTFRIEND", "1");
                            server2.SendResponse("ACCEPTFRIEND", "1");
                        }
                        else
                        {
                            //잘못된 친구 요청입니다.
                            server.SendResponse("ACCEPTFRIEND", -1);
                        }
                    } else if (header.Equals("SENDFRIENDREQUEST"))
                    {
                        if (server.username.Equals(content)) server.SendResponse("SENDFRIENDREQUEST", "-1");
                        else
                        {
                            Server targetServer = FindServer(content);
                            if (targetServer == null) server.SendResponse("SENDFRIENDREQUEST", "-1"); //없는 사용자입니다.
                            else
                            {
                                server.SendResponse("SENDFRIENDREQUEST", "1"); // 친구 요청 보냄
                                targetServer.SendResponse("FRIENDREQUEST", server.username);
                            }
                        }
                    }
                    else if (header.Equals("FRIENDSLIST"))
                    {
                        server.SendResponse("FRIENDSLIST", GetFriendListString(server.username));
                    }
                    else if (header.Equals("FRIENDREMOVE"))
                    {
                        FriendRemove(content, server);
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

                    } else if (header.Equals("SENDQUESTION"))
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
                        GuessAnswer(content, server);
                    }
                    else if (header.Equals("BUZZER"))
                    {
                        Buzzer(server);
                    } else if (header.Equals("EXITGAME"))
                    {
                        ExitGame(server);
                    } else if (header.Equals("SETBCOUNT"))
                    {
                        SetBcount(server);
                    } else if (header.Equals("GETRANK"))
                    {
                        Parse_rank(server);
                    }
                    //알 수 없는 header일때
                    else
                    {
                        server.SendResponse(header, content);
                    }
                }
            }
            catch
            {
                ExitGame(server);

                parentForm.PrintLog("disconnect client | ip : " + server.clientIP.ToString() + " | room : " + server.roomnum().ToString());
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

        private Server FindServer(string username)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                if (servers[i].username == username) return servers[i];
            }

            return null;
        }

        #endregion

        #region 로그인 기능

        private Dictionary<string, string> loginData = new Dictionary<string, string>();

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
            }
            reader.Close();

        }

        private void SignIn(string username, string password, Server server)
        {
            if (loginData.ContainsKey(username))
            {
                if (loginData[username].Equals(password))
                {
                    if (servers.Find(s => s.username.Equals(username)) == null)
                    {
                        parentForm.PrintLog("login user : " + username + ", " + password);
                        server.SendResponse("SIGNIN", username);
                        server.username = username;
                        server.set_winpoint(0);
                        return;
                    }
                }
            }

            server.SendResponse("SIGNIN", string.Empty);
        }

        private void SignUp(string username, string password, Server server)
        {
            if (loginData.ContainsKey(username) || username.Equals("NONE"))
            {
                server.SendResponse("SIGNUP", 0);
            }
            else
            {
                parentForm.PrintLog("create new account : " + username + ", " + password);
                loginData.Add(username, password);

                conn = new SQLiteConnection("Data Source=login_info.db");
                conn.Open();
                string query = "insert into idpw (ID,pw,wins) values ('" +
                    username + "','" + password + "','0')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

                server.SendResponse("SIGNUP", 1);
            }
        }

        private void SignOut(Server server)
        {
            servers.ForEach(s =>
            {
                if (s.username.Equals(server.username))
                {
                    s.username = "NONE";
                    s.SendResponse("SIGNOUT", "1");
                    return;
                }
            });
        }
        #endregion

        #region 친구 관리
        private List<Tuple<string, string>> friendshipList;

        private void JoinUserGameRoom(string username, Server server)
        {
            GameRoom room = FindUserGameRoom(username);
            if (room == null)
            {
                //친구가 참가중인 방이 없습니다.
                server.SendResponse("JOINFRIENDROOM", "-1");
            }
            else if (room.starting) {
                //친구의 방이 이미 게임중입니다.
                server.SendResponse("JOINFRIENDROOM", "-2");
            }
            else if (room.Max())
            {
                //친구의 방이 가득 찼습니다.
                server.SendResponse("JOINFRIENDROOM", "-3");
            }
            else
            {
                RoomJoin(room.name, server);
            }
        }

        private void FriendRemove(string friendName, Server server)
        {
            int pos = -1;

            for (int i = 0; i < friendshipList.Count; i++)
            {
                if (friendshipList[i].Item1.Equals(friendName) && friendshipList[i].Item2.Equals(server.username))
                {
                    pos = i;
                    break;
                }
                else if (friendshipList[i].Item1.Equals(server.username) && friendshipList[i].Item2.Equals(friendName))
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                Tuple<string, string> findItem = friendshipList[pos];

                conn = new SQLiteConnection("Data Source=friend_info.db");
                conn.Open();

                string query = "DELETE FROM friendship WHERE username1='" + findItem.Item1 + "' AND username2='" + findItem.Item2 + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

                friendshipList.RemoveAt(pos);

                int friendPos = servers.FindIndex(f => f.username.Equals(friendName));
                if (friendPos != -1) { servers[friendPos].SendResponse("FRIENDSLIST", GetFriendListString(friendName)); }
            }

            server.SendResponse("FRIENDREMOVE", pos);
        }

        private string GetFriendListString(string username)
        {
            List<string> friendList = new List<string>();
            friendshipList.ForEach(f =>
            {
                if (f.Item1 == username) friendList.Add(f.Item2);
                else if (f.Item2 == username) friendList.Add(f.Item1);
            });

            string friendString = string.Empty;

            friendList.ForEach(f =>
            {
                friendString += string.Format("{0},", f);
            });

            if (friendString.Length > 0)
            {
                friendString = friendString.Substring(0, friendString.Length - 1);
            }

            return friendString;
        }

        private GameRoom FindUserGameRoom(string username)
        {
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].players.Find(p => p.username == username) != null) return gameRooms[i];
            }

            return null;
        }

        private bool AddFriendShip(Server server1, Server server2)
        {
            if (server1 == null || server2 == null) return false;
            if (ContainFriendship(server1.username, server2.username)) return false;
            else
            {
                friendshipList.Add(new Tuple<string, string>(server1.username, server2.username));

                conn = new SQLiteConnection("Data Source=friend_info.db");
                conn.Open();
                string query = "insert into friendship (username1,username2) values ('" +
                    server1.username + "','" + server2.username + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

                return true;
            }
        }

        private bool ContainFriendship(string username1, string username2)
        {
            return friendshipList.Contains(new Tuple<string, string>(username1, username2))
                || friendshipList.Contains(new Tuple<string, string>(username2, username1));
        }

        private void LoadFriendData()
        {
            friendshipList = new List<Tuple<string, string>>();

            //파일에서 아이디-패스워드 데이터 읽어오기. 
            if (!System.IO.File.Exists("friend_info.db"))
                SQLiteConnection.CreateFile("friend_info.db");
            conn = new SQLiteConnection("Data Source=friend_info.db");
            conn.Open();
            string query = "create table if not exists friendship (username1 varchar(20), username2 varchar(20)" +
                ", primary key (username1,username2))";

            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "select * from friendship";
            cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                friendshipList.Add(new Tuple<string, string>(reader["username1"].ToString(), reader["username2"].ToString()));
            }
            reader.Close();
        }
        #endregion

        #region 방 관리
        private List<GameRoom> gameRooms = new List<GameRoom>();
        private bool RoomCreate(string roomName, int max, Server roomOwner)
        {
            for (int i = 0; i < gameRooms.Count; i++)
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

        private void RefreshRoom()
        {
            //현재 로비에 있는 모든 플레이어에게 방의 변동을 전달
            for (int i = 0; i < servers.Count; i++)
            {
                if (servers[i].roomnum() == 0)
                {
                    servers[i].SendResponse("ROOMLIST", GetRoomListString());
                }
            }
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
                    }else if (gameRooms[i].starting)
                    {
                        index = -4;
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
                server.SendResponse("ROOMJOIN", -1);
            }
            else if (index == -2)
            {
                server.SendResponse("ROOMJOIN", -2);
            }else if(index == -4)
            {
                server.SendResponse("ROOMJOIN", -4);
            }
            else
            {
                if (gameRooms[index].Is_banned(server))
                {
                    server.SendResponse("ROOMJOIN", "-3");
                    return;
                }
                server.ready = false;
                //기존에 방에 있던 플레이어들에게 해당 플레이어가 들어와서 생긴 방의 변동을 자동으로 전달
                gameRooms[index].AddPlayer(server);
                gameRooms[index].players.ForEach(p => PlayerList(gameRooms[index].name, p));
                server.SendResponse("ROOMJOIN", gameRooms[index].name);

                //일반 플레이어 화면으로 세팅 이거 근데 순서 꼬이면 어떡하지? 한번 해보고 문제 있으면 ROOMJOIN시 인자로 보내서 그때 같이 처리하는걸로
                server.SendResponse("GAMESCREEN", "PLAYERWAIT");
                ReadyList(roomName, server);

                RefreshRoom();
            }
        }

        private void RoomOut(string num, Server server)
        {
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    gameRooms[i].RemovePlayer(server);
                    if (gameRooms[i].players.Count == 0)
                    {
                        gameRooms.RemoveAt(i);
                    }
                    else
                    {
                        //게임중에 나가면 게임 강제 종료
                        if (gameRooms[i].starting)
                        {
                            ForceGameOver(gameRooms[i]);
                        }
                        else
                        {
                            //남아있는 플레이어들에게 해당 플레이어가 나가서 생긴 방의 변동을 자동으로 전달
                            gameRooms[i].players.ForEach(p => PlayerList(gameRooms[i].name, p));
                        }
                    }

                    server.change_room(0);
                    if (num != null)
                        if (num.Equals("kick"))
                            server.SendResponse("KICK", 0);
                        else
                            server.SendResponse("ROOMOUT", 0);

                    RefreshRoom();

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

            server.SendResponse("PLAYERLIST", playerListString);
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

            server.SendResponse("READYLIST", readyListString);
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

            int namelength = server.username.Length;
            if(content.Length>namelength+1)
            if (content[namelength + 1] == '/')
            {
                ChatCommand(content.Substring(namelength + 1), server, gameRoom);
                return;
            }


            string chatListString = string.Empty;

            gameRoom.chats.Add(content);
            gameRoom.chats.ForEach(chat =>
            {
                chatListString = chatListString + "," + chat;
            });

            chatListString = chatListString.Substring(1, chatListString.Length - 1);

            gameRoom.players.ForEach(p =>
            {
                p.SendResponse("ROOMCHAT", chatListString);
            });
        }
        private void ChatCommand(string command, Server server, GameRoom room) {
            string[] parsed_cmd = command.Split(' ');
            if (parsed_cmd[0].Equals("/newhost"))
            {
                if (server.username.CompareTo(room.ownerPlayer.username) != 0)
                    return;
                int i;
                if (parsed_cmd.Length < 2)
                    return;
                for (i = 0; i < room.players.Count; i++)
                    if (room.players[i].username.CompareTo(parsed_cmd[1]) == 0)
                        break;
                if (i == room.players.Count)
                    return;
                room.SetOwner(room.players[i]);
                server.SendResponse("GAMESCREEN", "PLAYERWAIT");
                room.players[i].SendResponse("GAMESCREEN", "OWNERWAIT");
                room.players[i].ready = true;
                room.Swap_owner_in_players(room.players[i]);
                room.players.ForEach(p =>
                {
                    PlayerList(room.name, p);
                    ReadyList(room.name, p);
                });
            } else if (parsed_cmd[0].Equals("/kick"))
            {
                if(server.username.CompareTo(room.ownerPlayer.username) != 0)
                    return;
                int i;
                if (parsed_cmd.Length < 2)
                    return;
                for (i = 0; i < room.players.Count; i++)
                    if (room.players[i].username.CompareTo(parsed_cmd[1]) == 0)
                        break;
                if (i == room.players.Count)
                    return;
                room.Ban_user(room.players[i]);
                RoomOut("kick", room.players[i]);
            } else if (parsed_cmd[0].Equals("/whisper")|| parsed_cmd[0].Equals("/w"))
            {
                int reciver=-1;
                int sender=-1;
                if (parsed_cmd.Length < 2)
                    return;
                for (int i = 0; i < room.players.Count; i++) {
                    if (room.players[i].username.CompareTo(parsed_cmd[1]) == 0)
                        reciver= i;
                    if (room.players[i]==server)
                        sender=i;
                }        
                if (reciver == room.players.Count)
                    return;
                string msg=sender.ToString();
                msg+=command.Substring(parsed_cmd[0].Length + parsed_cmd[1].Length + 1);
                room.players[reciver].SendResponse("WHISPER", msg);

            }
        }


        #endregion

        #region 게임 진행

        private void ForceGameOver(GameRoom room)
        {
            room.starting = false;
            room.players.ForEach(p =>
            {
                if (p == room.GetOwner())
                {
                    p.SendResponse("GAMESCREEN", "OWNERWAIT");
                }
                else
                {
                    GameReady(p); //다시 대기 중 상태로 바꾸기 위해
                    p.SendResponse("GAMESCREEN", "PLAYERWAIT");
                }
            });

            room.players.ForEach(p =>
            {
                PlayerList(room.name, p);
                ReadyList(room.name, p);

                p.SendResponse("FORCEGAMEOVER", "1");
            });
        }

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
                    questionerList[i].SendResponse("GAMESCREEN", "UNLOCKBUZZER");
                }
                else
                {
                    //나머지는 대기
                    questionerList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                    questionerList[i].SendResponse("GAMESCREEN", "UNLOCKBUZZER");
                }
            }

            room.SendCurrentQuestioner();
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
            int questioner;
            room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERWAIT");

                questioner=room.NextQuestioner();

            List<Server> qList = room.GetQuestionerList();
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
            if (room.Get_total_q() == 20) // 모든 플레이어가 도전 기회를 소모해서 게임 종료하는 조건 
            {
                RoomChat("실패! 정답은 " + room.word, server);
                Set_nextround(server);
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
        private void Get_scores(Server server)
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
            List<Server> pList = room.GetPlayerList();
            string warr=null;
            for(int i=0; i < pList.Count; i++)
            {
               warr+= pList[i].get_winpoint().ToString()+",";
            }
            if (warr != null)
                warr=warr.Remove(warr.Length - 1);
            for (int i = 0; i < pList.Count; i++)
            {
                pList[i].SendResponse("GETWINS", warr);
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
            room.Plus_total_q();
            List<Server> qList = room.GetQuestionerList();
            for (int i = 0; i < qList.Count; i++)
            {
                qList[i].SendResponse("GAMESCREEN", "UNLOCKBUZZER");
            }
            if (room.word.CompareTo(guess) == 0)
            {
                server.win(); //점수추가
                RoomChat("정답!", server);
                Set_nextround(server);
            }
            else
            {
                RoomChat("땡", server);
            }
            int tok;
            List<Server> ql = room.GetQuestionerList();
            for (tok = 0; tok < ql.Count(); tok++)
            {
                if (ql[tok].get_remain_chance() != 0)
                    break;
            }
            if (tok == ql.Count()) // 모든 플레이어가 도전 기회를 소모해서 게임 종료하는 조건 
            {
                RoomChat("실패! 정답은 " + room.word, server);
                Set_nextround(server);
            }

        }
        private void Set_nextround(Server server)
        {
            Get_scores(server);
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
            List<Server> qList;
            room.NextPresenter();
            qList = room.GetQuestionerList();
            if (room.GetPresenterNum() != 0)
            {//출제자 한바퀴만
                room.ClearChat();
                RoomChat("다음 라운드!", server);
                room.GetPresenter().SendResponse("GAMESCREEN", "PRESENTERCHOICE");
                room.Set_round();
                for (int i = 0; i < qList.Count; i++)
                {
                    qList[i].set_remain_chance();
                    qList[i].SendResponse("SETBCOUNT", "5");
                    qList[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                    qList[i].SendResponse("GAMESCREEN", "LOCKBYBUZZER");
                }
            }
            else //대기방으로
            {
                qList = room.GetPlayerList();
                RoomChat("게임 종료!", server);
                room.starting = false;
                for (int i = 0; i < qList.Count; i++)
                {
                    qList[i].update_db();
                    if (qList[i].username.CompareTo(room.GetOwner().username) == 0)
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

            List<Server> qList = room.GetQuestionerList();

            for (int i = 0; i < qList.Count; i++)
            {
                if (qList[i].username != server.username)
                    qList[i].SendResponse("GAMESCREEN", "LOCKBYBUZZER");
            }
        }
        private void SetBcount(Server server)
        {
            server.SendResponse("SETBCOUNT", server.get_remain_chance().ToString());
        }

        private void ExitGame(Server server)
        {
            for (int i = 0; i < gameRooms.Count; i++)
            {
                if (gameRooms[i].ContainPlayer(server))
                {
                    gameRooms[i].RemovePlayer(server);
                    if (gameRooms[i].players.Count == 0)
                    {
                        gameRooms.RemoveAt(i);
                    }
                    else
                    {
                        if (gameRooms[i].starting) ForceGameOver(gameRooms[i]);
                        else gameRooms[i].players.ForEach(p => PlayerList(gameRooms[i].name, p));
                    }
                    return;
                }
            }
        }
        #endregion

        #region 기타
        private void Parse_rank(Server server)
        {
            conn = new SQLiteConnection("Data Source=login_info.db");
            conn.Open();
            string query = "select ID,wins from idpw order by wins desc limit 15";
            SQLiteCommand cmd=new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            string rank_arr=null;
            while (reader.Read())
            {
                rank_arr += reader["ID"].ToString()+','+reader["wins"].ToString()+',';

            }
            conn.Close();
            server.SendResponse("RANKING", rank_arr);

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
        private List<Server> banned;

        //owner가 시작 요청을 보낼 경우 보내게 될 응답. 게임 시작 신호를 모든 플레이어에게 보낸다.

        public void GameStart()
        {
            if(players.Count > 1)
            {
                for (int i=0; i < players.Count; i++)
                {
                    if (players[i].ready == false)
                    {
                        ownerPlayer.SendResponse("GAMESTART", "0");
                        ownerPlayer.SendResponse("GAMESCREEN", "OWNERWAIT");
                        return;
                    }
                    players[i].set_remain_chance();
                    players[i].SendResponse("SETBCOUNT","5");
                }
                starting = true;

                presenter = 0;
                currentQuestioner = 0;
                total_questions = 0;

                //채팅 초기화
                ClearChat();

                //첫번째 사람에게 가장 첫 출제자 권한 부여
                players[0].SendResponse("GAMESCREEN", "PRESENTERCHOICE");
                presenter = 0;

                //나머지 플레이어들에게
                for(int i=1; i<players.Count; i++)
                {
                    players[i].SendResponse("GAMESCREEN", "QUESTIONERWAIT");
                    players[i].SendResponse("GAMESCREEN", "LOCKBYBUZZER");
                }
            }
        }
        
        public int NextQuestioner()
        {
            List<Server> questionerList = GetQuestionerList();
            currentQuestioner++;
            if (questionerList.Count == currentQuestioner) currentQuestioner = 0;

            SendCurrentQuestioner();

            return currentQuestioner;
        }

        public void SendCurrentQuestioner()
        {
            List<Server> questionerList = GetQuestionerList();
            if (questionerList.Count == 0) return;
            players.ForEach(p => p.SendResponse("CURRENTQUESTIONER", questionerList[currentQuestioner].username));
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
            banned = new List<Server>();
        }

        public void ClearChat()
        {
            chats.Clear();

            players.ForEach(p =>
            {
                p.SendResponse("ROOMCHAT", string.Empty);
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
        public void NextPresenter() { presenter++;
            if (players.Count() == presenter)
                presenter = 0;
        }
        public int GetPresenterNum() { return presenter; }
        public void Set_round()
        {
            currentQuestioner = 0;
            total_questions = 0;
            word = null;
        }
        public Server GetOwner()
        {
            return ownerPlayer;
        }
        public void SetOwner(Server owner)
        {
            ownerPlayer = owner;
        }
        public void Swap_owner_in_players(Server newowner){
            Server server = newowner;
            for(int i = 0;i< players.Count;i++)
            {
                if (players[i] == server)
                {
                    players[i] = players[0];
                    players[0] = server; break;
                }
            }
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
        public List<Server> GetPlayerList()
        {
            return players;
        }
        public int Get_total_q() { return total_questions; }
        public void Plus_total_q() { total_questions++; }
        private static int roomCount = 1;
        private static int NextRoom() { return roomCount++; }
        public void Ban_user(Server server)
        {
            banned.Add(server);
        }
        public bool Is_banned(Server server)
        {
            if(banned!=null)
            if (banned.Contains(server)) return true;
            return false;
        }
    }
}
