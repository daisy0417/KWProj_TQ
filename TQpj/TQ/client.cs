using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TQ
{
    public partial class Client
    {
        StreamReader sreader;
        StreamWriter swriter;

        ClientForm parentForm;

        public string username = "None";
        private bool activate = false;
        public bool Activate { get { return activate; } } //현재 클라이언트가 서버와 접속중인지

        public Client(ClientForm parentForm)
        {
            this.parentForm = parentForm;
        }

        //서버와 접속을 시작한다.
        public void Start()
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                swriter = new StreamWriter(client.GetStream());
                swriter.WriteLine(0);
                swriter.Close();
                client.Close();

                TcpClient client2 = new TcpClient();
                client2.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                sreader = new StreamReader(client2.GetStream());
                int port = int.Parse(sreader.ReadLine());
                sreader.Close();
                client.Close();

                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), port);
                sreader = new StreamReader(client.GetStream());
                swriter = new StreamWriter(client.GetStream());
                swriter.AutoFlush = true;

                Thread thread = new Thread(Connecting);
                thread.IsBackground = true;
                thread.Start();

                activate = true;
            }
            catch
            {
                parentForm.ShowMessageBox("서버 연결 실패");
            }
        }

        //서버에 요청을 보낸다.
        private void SendRequest(string header, string content)
        {
            swriter.WriteLine(header + "|" + content);
        }

        //응답을 대기하는 부분. 스레드로 실행됨
        private void Connecting()
        {
            while (true)
            {
                string msg = sreader.ReadLine();
                ResponseProcess(msg);
            }
        }

        //Server - chat_server에서 보낸 응답을 처리
        private void ResponseProcess(string msg)
        {
            string[] response = msg.Split('|');
            string header = response[0];
            string content = response[1];

            if (header.Equals("NONE"))
            {
                parentForm.ShowMessageBox(content);
            }
            else if (header.Equals("GETROOM"))
            {
                parentForm.ViewRoom(int.Parse(content));
            }
            else if (header.Equals("SIGNIN"))
            {
                parentForm.SignIn(content);
            }
            else if (header.Equals("SIGNUP"))
            {
                parentForm.SignUp(content.Equals("1"));
            }
            else if (header.Equals("ROOMLIST"))
            {
                if (!content.Equals(string.Empty))
                {
                    List<string> roomList = content.Split(':').ToList();
                    parentForm.RoomList(roomList);
                }
                else
                {
                    parentForm.RoomList(new List<string>());
                }

            }
            else if (header.Equals("ROOMCREATE"))
            {
                parentForm.RoomCreate(content.Equals("1"));
            }
            else if (header.Equals("ROOMJOIN"))
            {
                parentForm.RoomJoin(content);
            }
            else if (header.Equals("ROOMOUT"))
            {
                parentForm.RoomOut();
            }
            else if (header.Equals("ROOMCHAT"))
            {
                if (!content.Equals(string.Empty))
                {
                    List<string> roomChatList = content.Split(',').ToList();
                    parentForm.RoomChat(roomChatList);
                }
                else
                {
                    parentForm.RoomChat(new List<string>());
                }
            }
        }

    }
}