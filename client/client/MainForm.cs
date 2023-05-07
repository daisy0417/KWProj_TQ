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

        private void main_login_btn_Click(object sender, EventArgs e)
        {
            panel1_login.Visible = true;
        }

        private void p1_login_btn_Click(object sender, EventArgs e)
        {
            p1_userName_label.Visible = false;
            p1_pw_label.Visible = false;
            p1_username_tbx.Visible = false;
            p1_pw_tbx.Visible = false;
            p1_1_ip_panel.Visible = true;

            // 로그인 버튼 눌렀을 때 유효성 검사
        }

        private void p1_1_ip_panel_VisibleChanged(object sender, EventArgs e)
        {
            p1_ip_label.Visible = true;
            p1_ip_tbx.Visible = true;
            p1_connect_btn.Visible = true;
        }

        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            // 서버 연결 안 됐을 경우 팝업 알림
        }
    }
}
