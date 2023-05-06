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
    internal class client
    {
        const int portmain = 5000;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        StreamReader sreader;
        StreamWriter swriter;
        int room;
        void client_start() //도입부,스레드로 connect 호출
        {
            Thread thread = new Thread(connect_room);
            thread.IsBackground = true;
            thread.Start();
        }
        void send(string msg)
        {
            swriter.WriteLine(msg);
        }
        void connect_room()// 입력받은 방 번호를 서버에 전송하고 포트 받아옴
                           //이후 서버의 메세지 수신하는 역할
        {
            TcpClient client = new TcpClient();
            client.Connect(ip, portmain);
            swriter = new StreamWriter(client.GetStream());
            swriter.WriteLine(room);
            swriter.Close();
            client.Close();

            TcpClient client2 = new TcpClient();
            client2.Connect(ip, portmain);
            sreader = new StreamReader(client2.GetStream());
            int port = int.Parse(sreader.ReadLine());
            sreader.Close();
            client.Close();

            client = new TcpClient();
            client.Connect(ip, port);
            sreader = new StreamReader(client.GetStream());
            swriter = new StreamWriter(client.GetStream());
            swriter.AutoFlush = true;

            while (true)
            {
                string msg = sreader.ReadLine();
                Console.WriteLine(msg);
            }

        }
        /*
        static void Main(string[] args)
        {
            client a = new client();
            Console.WriteLine("room?:");
            a.room = int.Parse(Console.ReadLine());
            a.client_start();
            while (true)
            {
                string msg = Console.ReadLine();
                a.send(msg);
            }
        }
        */
    }
}
