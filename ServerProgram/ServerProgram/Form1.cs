using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProgram
{
    public partial class Form1 : ServerForm
    {
        MainServer mainServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(mainServer != null) PrintLog("이미 서버가 실행중");
            else StartServer();
        }

        private void StartServer()
        {
            mainServer = new MainServer(this);
            mainServer.server_start();
            PrintLog("서버 시작");
        }

        public override void PrintLog(string content)
        {
            if (logTB.InvokeRequired)
            {
                logTB.Invoke(new MethodInvoker(delegate { logTB.Text = logTB.Text + content + "\r\n"; }));
            }
            else
            {
                logTB.Text = logTB.Text + content + "\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartServer();
        }
    }
}
