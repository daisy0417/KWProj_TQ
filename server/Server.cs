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

namespace ServerProgram
{
    internal class Server
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private int room;
        private int port;
        public int Port { get { return port; } }

        public Server(IPAddress ip, int port, int room)
        { //서버 생성자. 클라스 생성과 함께 서버연결
            this.port = port;
            this.room = room;
            this.listener = new TcpListener(ip, port);
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

        public void write_client(int room, string msg) // room 번호가 같으면 클라이언트에 메세지 전송 
        {
            if (this.room == room)
            {
                this.writer.WriteLine(msg);
            }
        }
        public int roomnum() { return this.room; }
    }

    public class MainServer
    {
        #region 통신 기능
        private List<Server> servers = new List<Server>();
        private ServerForm parentForm;

        private const int portmain = 5000; //기본(로비)포트
        private int portCount = 1;
        private IPAddress ip = IPAddress.Parse("127.0.0.1"); // ip는 입력 받아 저장

        public int NewPort() { return portmain + portCount++; }

        public MainServer(ServerForm parentForm)
        {
            this.parentForm = parentForm;
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
                    TcpListener listener = new TcpListener(ip, portmain);
                    listener.Start();
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader sread = new StreamReader(client.GetStream());
                    string msg = sread.ReadLine();
                    int room = int.Parse(msg); //방번호 받고 포트번호 주기
                    sread.Close();
                    client.Close();

                    int newPort = NewPort();

                    TcpClient client2 = listener.AcceptTcpClient();
                    StreamWriter swrite = new StreamWriter(client2.GetStream());
                    swrite.WriteLine(newPort);
                    swrite.Close();
                    client2.Close();
                    listener.Stop();

                    servers.Add(new Server(IPAddress.Parse("127.0.0.1"), newPort, 0));
                    Thread thread1 = new Thread(chat_server);
                    thread1.IsBackground = true;
                    thread1.Start();

                    parentForm.PrintLog("new clent connected | port : " + newPort + " | room : " + room);
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
                    }else if (header.Equals("SETROOM")){
                        int newRoom = 0;

                        if(int.TryParse(content, out newRoom))
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

                    }else if (header.Equals("SIGNUP"))
                    {
                        string[] idpw = content.Split(':');
                        SignUp(idpw[0], idpw[1], server);
                    }
                    //방 관련
                    else if (header.Equals("ROOMLIST"))
                    {
                        server.SendClient("ROOMLIST|" + GetRoomListString());
                    }else if (header.Equals("ROOMCREATE"))
                    {
                        string[] roomInfo = content.Split(',');
                        if (RoomCreate(roomInfo[0], int.Parse(roomInfo[1]), server))
                        {
                            server.SendClient("ROOMCREATE|1");
                        }else
                        {
                            server.SendClient("ROOMCREATE|0");
                        }
                    }
                    else if (header.Equals("ROOMJOIN"))
                    {
                        RoomJoin(content, server);
                    }else if (header.Equals("ROOMOUT"))
                    {
                        RoomOut(server);
                    }
                    //방 채팅
                    else if (header.Equals("ROOMCHAT"))
                    {
                        RoomChat(content, server);
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
                parentForm.PrintLog("disconnect client | port : " + 
                    server.Port.ToString() + " | room : " + server.roomnum().ToString());
                servers.Remove(server);
            }
        }
        #endregion

        #region 로그인 기능

        private Dictionary<string, string> loginData = new Dictionary<string, string>();

        private void LoadLoginData()
        {
            //파일에서 아이디-패스워드 데이터 읽어오기. 아직 구현 안됨.

            //임시 데이터들
            loginData.Add("admin", "1234");
            loginData.Add("player1", "1234");
            loginData.Add("player2", "1234");
            loginData.Add("player3", "1234");
            loginData.Add("player4", "1234");
        }

        private void SignIn(string username, string password, Server server)
        {
            if (loginData.ContainsKey(username))
            {
                if (loginData[username].Equals(password))
                {
                    parentForm.PrintLog("login user : " + username + ", " + password);
                    server.SendClient("SIGNIN|" + username);
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

            GameRoom newGameRoom = new GameRoom(roomName, max);
            newGameRoom.AddPlayer(roomOwner);
            gameRooms.Add(newGameRoom);

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
                gameRooms[index].AddPlayer(server);
                server.SendClient("ROOMJOIN|" + gameRooms[index].name);
            }
        }

        private void RoomOut(Server server)
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
    }

    //방 정보를 담고있음.
    internal class GameRoom
    {
        public string name;
        public int max;
        public int room;
        public List<Server> players;
        public bool starting = false;
        public List<string> chats;

        //owner가 시작 요청을 보낼 경우 보내게 될 응답. 게임 시작 신호를 모든 플레이어에게 보낸다.
        public void GameStart()
        {
            if(players.Count == max)
            {
                for(int i=0; i<players.Count; i++)
                {
                    players[i].SendClient("GAMESTART|0");
                }
            }
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
        }

        private static int roomCount = 1;
        private static int NextRoom() { return roomCount++; }
    }
}
