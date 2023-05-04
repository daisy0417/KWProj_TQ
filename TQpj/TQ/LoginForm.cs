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
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void txtBox()
        {
            // Create an instance of the TextBox control
            nameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(nameTxtBox.Text=="" || ServerTxtBox.Text=="")
            {
                MessageBox.Show("이름과 IP를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
                this.Close();
            }
            
        }

        private void ServerTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력 가능
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }
    }
}
