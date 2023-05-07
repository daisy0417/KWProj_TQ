using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TQ
{
    public partial class MainForm : ClientForm
    {
       
        public MainForm()
        {
            InitializeComponent();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            /*
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
            */
            titleLabel.Visible = false;

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            roomListForm rLf = new roomListForm();
            this.Hide();
            rLf.ShowDialog();
            //this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TryConnectServer();
        }

   
    }
}
