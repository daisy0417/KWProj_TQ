using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TQ
{
    public partial class LoginForm : ClientForm
    {
        private string name;
        public string Value
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        

        public LoginForm()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            GameStartForm gForm = new GameStartForm();
       

            if (string.IsNullOrEmpty(nameTxtBox.Text) || string.IsNullOrEmpty(ServerTxtBox.Text))
            {
                MessageBox.Show("이름과 IP를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nameCheck = string.Format("당신은 {0} 님이 맞습니까?", nameTxtBox.Text);
            var name_messageRes = MessageBox.Show(nameCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(name_messageRes == DialogResult.No)
            {
                return;                
            }

            string ipCheck = string.Format("서버의 ip는 {0} 이 맞습니까?", ServerTxtBox.Text);
            var ip_messageRes = MessageBox.Show(ipCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ip_messageRes == DialogResult.No)
            {
                return;
            }

            this.Hide();
            gForm.Value = nameTxtBox.Text;
            gForm.ShowDialog();
            this.Close();

            DialogResult = DialogResult.OK;
        }

        private void ServerTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스, '.'만 입력 가능
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            TryConnectServer();
        }
    }
}
