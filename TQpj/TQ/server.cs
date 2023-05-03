using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TQ
{
    class Servers
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private int port;
        private int room;
        public Servers(IPAddress ip, int port, int room)
        { //서버 생성자. 클라스 생성과 함께 서버연결
            this.port = port;
            this.room = room;
            this.listener = new TcpListener(ip, port);

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
        public void write_client(int room, string msg) // room 번호가 같으면 클라이언트에 메세지 전송 
        {
            if (this.room == room)
            {
                this.writer.WriteLine(msg);
            }
        }
        public int roomnum() { return this.room; }
    }
    public partial class server
    {

        Servers[] allserver = new Servers[15];//server 저장(chat서버만) 
        const int portmain = 5000; //기본(로비)포트
        IPAddress ip = IPAddress.Parse("127.0.0.1"); // ip는 입력 받아 저장
        int servernum = 1;//서버 수 
        void server_start()//lobby server를 시작. 한 번만 호출
        {
            Thread thread1 = new Thread(lobby_server);
            thread1.IsBackground = true;
            thread1.Start();
        }
        void msg_return(int room, string msg) // 보유한 서버에 대해 메세지 전달(방 번호 다르면 잘림)
        {
            for (int i = 0; i < servernum - 1; i++)
            {
                allserver[i].write_client(room, msg);
            }
        }
        void lobby_server()//스레드 내에서 새로운 클라이언트를 대기, 클라이언트가 접속하면 새 포트와 방 번호를 할당
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

                TcpClient client2 = listener.AcceptTcpClient();
                StreamWriter swrite = new StreamWriter(client2.GetStream());
                swrite.WriteLine(portmain + servernum);
                swrite.Close();
                client2.Close();
                listener.Stop();

                allserver[servernum - 1] = new Servers(ip, portmain + servernum, room);
                Thread thread1 = new Thread(chat_server);
                thread1.IsBackground = true;
                thread1.Start();
            }
        }
        void chat_server()//client에 대응하는 스레드, 메세지 대기 
        {
            int threadnum = servernum;
            servernum++;
            allserver[threadnum - 1].run_server(); //stream 생성
            while (true)//client 메세지 수신
            {
                string msg = allserver[threadnum - 1].read_client();
                msg_return(allserver[threadnum - 1].roomnum(), msg);
            }
        }

        /*
        static void Main(string[] args)
        {
            server a = new server();
            a.server_start();
            while (true)
            {
                string msg = Console.ReadLine();

            }

        }
        */

    }
}
