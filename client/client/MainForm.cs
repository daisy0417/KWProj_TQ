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
            panel1_login_server.Visible = true;
            //home_btn.Visible = true;
            p1_username_tbx.Text = null;
            p1_pw_tbx.Text = null;
        }

        #region panel1_login: 서버 연결 panel

        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(p1_ip_tbx.Text))
            {
                ShowMessageBox("IP를 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TryConnectServer(p1_ip_tbx.Text);
                p1_1_login_panel.Visible = true;
                p1_login_btn.Visible = true;
            }

        }

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
                p1_gameStart_btn.Visible = true;
                panel1_login_server.Visible = false;
                panel2_gameStart.Visible = true;
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
        #endregion

        #region panel1-1: 서버 연결 후 로그인 panel
        private void p1_ip_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, '.'만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }



        public override void ConnectServerResult(bool success)
        {
            if (success)
            {
                //연결 성공
                p1_connect_btn.Visible = false;
                p1_login_btn.Visible = true;
            }
            else
            {
                //연결 실패
                ShowMessageBox("서버 연결 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region panel2_gameStart: 로그아웃, 게임시작 가능
        private void p1_gameStart_btn_Click(object sender, EventArgs e)
        {
            p1_1_login_panel.Visible = false;
            panel1_login_server.Visible = false;
            panel2_gameStart.Visible = true;
        }

        private void panel2_gameStart_VisibleChanged(object sender, EventArgs e)
        {
            p2_welcome__label.Text = String.Format("{0} 님 환영합니다:)", p1_username_tbx.Text);
        }

        private void p2_gameStart_btn_Click(object sender, EventArgs e)
        {
            panel2_gameStart.Visible = false;
            panel3_roomList.Visible = true;
            p3_title_label.Visible = true;
        }
        #endregion

        #region panel3_roomList: 방 리스트 (방 생성, 입장, 퇴장)
        private void p3_makeRoom_btn_Click(object sender, EventArgs e)
        {
            p3_roomname_label.Text = "생성 할 방 이름";
            p3_create_btn.Visible = true;
            p3_people_label.Visible = true;
            p3_people_tbx.Visible = true;
        }

        public override void RoomList(List<string> roomList)
        {
            p3_nameList_tbx.Text = "";

            foreach (string room in roomList)
            {
                string[] roomInfo = room.Split(',');
                string roomName = roomInfo[0];
                string playerCount = roomInfo[1];
                string roomMax = roomInfo[2];

                p3_nameList_tbx.Text = p3_nameList_tbx.Text + $"{roomName}\t\t접속 인원 {playerCount,2} / {roomMax,-2}\r\n";
            }
        }

        public override void RoomCreate(bool success)
        {
            if (success)
            {
                ShowMessageBox("방 생성 성공","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("방 생성 실패","Fail",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public override void RoomJoin(string result)
        {
            if (result.Equals("-1"))
            {
                ShowMessageBox("존재하지 않는 방입니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result.Equals("-2"))
            {
                ShowMessageBox("정원이 가득 찼습니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                client.RequestSendRoomChat("시스템", client.username + "이(가) 방에 참가함");
                ShowMessageBox(result + " 방에 참가완료", "Room Join", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void RoomOut()
        {
            ShowMessageBox("방 나옴", "Room Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void p3_refresh_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        private void p3_create_btn_Click(object sender, EventArgs e)
        {
            string roomName = p3_roomname_tbx.Text;
            string roomMax = p3_people_tbx.Text;

            if (roomName != string.Empty && roomMax != string.Empty)
            {
                int num = 0;
                if (int.TryParse(p3_people_tbx.Text, out num))
                {
                    client.RequestRoomCreate(roomName, roomMax);
                }
            }
        }

        private void p3_Join_btn_Click(object sender, EventArgs e)
        {
            string roomName = p3_roomname_tbx.Text;

            if (roomName != string.Empty)
            {
                client.RequestRoomJoin(roomName);
            }
            panel3_roomList.Visible = false;
            panel4_waitRoom.Visible = true;
        }

        private void p3_Out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
        }

        private void panel3_roomList_VisibleChanged(object sender, EventArgs e)
        {
            p3_comein_label.Text = String.Format("{0} 님 접속 중", p1_username_tbx.Text);
        }

        #endregion


        
        public override void RoomChat(List<string> chatList)
        {
            p4_chat_tbx.Text = "";
            chatList.ForEach(chat =>
            {
                p4_chat_tbx.Text += chat + "\r\n";
            });
        }

        private void p4_send_btn_Click(object sender, EventArgs e)
        {
            string content = p4_message_tbx.Text;
            client.username = p1_username_tbx.Text; // 추가됨
            if (content != string.Empty)
            {
                client.RequestSendRoomChat(client.username, content);
                p4_message_tbx.Text = "";
            }
        }

        private void panel4_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            // 방 이름 - 접속 인원 / 최대 정원
        }

        private void p1_1_login_panel_VisibleChanged(object sender, EventArgs e)
        {
            p1_login_btn.Visible = true;
        }
    }
}