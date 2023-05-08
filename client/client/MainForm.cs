using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class MainForm : ClientForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TryConnectServer();
        }
        
        private void main_login_btn_Click(object sender, EventArgs e)
        {
            panel1_login.Visible = true;
            //home_btn.Visible = true;
            p1_username_tbx.Text = null;
            p1_pw_tbx.Text = null;
        }

        #region 로그인 panel
        private void p1_login_btn_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 눌렀을 때 유효성 검사
            string username = p1_username_tbx.Text;
            string password = p1_pw_tbx.Text;
            DialogResult result = DialogResult.None;

            /*
            if (username != string.Empty && password != string.Empty)
            {
                try
                {
                    client.RequestSignIn(username, password);
                }catch(NullReferenceException nre)
                {
                    return;
                } 
            }
           */ 

            if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
            {
                ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string nameCheck = string.Format("당신은 {0} 님이 맞습니까?", p1_username_tbx.Text);
                var name_messageRes = MessageBox.Show(nameCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (name_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    name_messageRes = DialogResult.Yes;
                }

                string pwCheck = string.Format("비밀번호는 {0} 이 맞습니까?", p1_pw_tbx.Text);
                var pw_messageRes = MessageBox.Show(pwCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pw_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    pw_messageRes = DialogResult.Yes;
                }

                if (pw_messageRes == DialogResult.Yes && name_messageRes == DialogResult.Yes)
                {
                    result = DialogResult.Yes;
                }
            }

            if (result == DialogResult.Yes)
            {
               // p1_1_ip_panel.Visible = true;
                //p1_connect_btn.Visible = true;
            }

        }

        /*
        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            // 서버 연결 안 됐을 경우 팝업 알림
            //TryConnectServer();
            p1_gamestart_btn.Visible = true;
        }
        */

        public override void SignIn(string username)
        {
            if (username != string.Empty)
            {
                client.username = username;
                ShowMessageBox("로그인 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("로그인 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void SignUp(bool success)
        {
            if (success)
            {
                ShowMessageBox("회원가입 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("회원가입 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        /*
        #region 서버 연결 panel
        private void p1_ip_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, '.'만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(p1_ip_tbx.Text))
            {
                ShowMessageBox("IP를 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TryConnectServer(p1_ip_tbx.Text);
            }

        }

        public override void ConnectServerResult(bool success)
        {
            if (success)
            {
                //연결 성공
                p1_connect_btn.Visible = false;
                p1_gameStart_btn.Visible = true;
            }
            else
            {
                //연결 실패
                ShowMessageBox("서버 연결 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 게임 시작 화면 panel
        #endregion
        */

    }
}