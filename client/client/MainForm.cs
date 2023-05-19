using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        /// <summary>
        /// 메인 화면에서 로그인 화면으로 넘어가는 이벤트
        /// </summary>
        private void main_login_btn_Click(object sender, EventArgs e)
        {
            panel1_login_server.Visible = true;
            p1_username_tbx.Text = null;
            p1_pw_tbx.Text = null;
        }

        #region panel1_login: 서버 연결 panel
        /// <summary>
        /// 서버 연결하기 버튼 클릭 시 이벤트
        /// 아무것도 입력하지 않으면 팝업 띄움.
        /// 그게 아니라면, 서버 연결하고 로그인 패널로 넘어감
        /// </summary>
        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(p1_ip_tbx.Text))
            {
                ShowMessageBox("IP를 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TryConnectServer(p1_ip_tbx.Text);
                p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
                p1_login_btn.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
//                p1_1_login_panel.Visible = true;
//                p1_login_btn.Visible = true;
            }
        }

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
                p1_connect_btn.Invoke(new MethodInvoker(delegate { p1_connect_btn.Visible = false; }));
                p1_login_btn.Invoke(new MethodInvoker(delegate { p1_login_btn.Visible = true; }));
                /*
                p1_connect_btn.Visible = false;
                p1_login_btn.Visible = true;
                */
            }
            else
            {
                //연결 실패
                ShowMessageBox("서버 연결 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region panel1-1: 서버 연결 후 로그인 panel
        /// <summary>
        /// 기존의 서버 연결하는 패널 위로 로그인 패널이 나타남
        /// </summary>
        private void p1_1_login_panel_VisibleChanged(object sender, EventArgs e)
        {
            p1_signUp_btn.Invoke(new MethodInvoker(delegate { p1_signUp_btn.Visible = true; }));
            p1_login_btn.Invoke(new MethodInvoker(delegate { p1_login_btn.Visible = true; }));
            /*
            p1_signUp_btn.Visible = true;
            p1_login_btn.Visible = true;
            */
        }

        /// <summary>
        /// 로그인 버튼을 눌렀을 때, 각 경우에 따라 다른 팝업 창 띄움
        /// </summary>
        static string message;
        readonly object locker=new object();
        bool islock = false;


        public override void SignUp(bool success)
        {
            lock (locker)
            {
                islock = true;
                if (success)
                    message = "success";
                else
                    message = "failed";
                islock = false;
                Monitor.Pulse(locker);
            }
        }

        private void p1_signUp_btn_Click(object sender, EventArgs e)
        {
            string username = p1_pw_tbx.Text;
            string password = p1_username_tbx.Text;
            DialogResult result;

            if (username != string.Empty && password != string.Empty)
            {
                client.RequestSignUp(username, password);
            }
            // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
            if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
            {
                ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 입력 정보가 맞는 지 확인하는 팝업 띄움
            // 팝업에 Yes, No 버튼이 있음. No가 입력되면 다시 입력 창으로 되돌아감 
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
                    result = DialogResult.Yes;
                }

                if (result == DialogResult.Yes)
                {

                    client.RequestSignUp(p1_username_tbx.Text, p1_pw_tbx.Text);
                    islock = true;
                    lock (locker)
                    {
                        while (islock == true)
                        {
                            Monitor.Wait(locker);
                        }
                    }
                    if (message.Equals("success"))
                    {
                        MessageBox.Show("회원가입 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("이미 가입되어 있습니다.", "SignUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public override void SignIn(string username)
        {
            lock (locker)
            {
                islock= true;
                message= username;
                islock= false;
                Monitor.Pulse(locker);
            }
        }

        private void p1_login_btn_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 눌렀을 때 유효성 검사
            string username = p1_username_tbx.Text;
            string password = p1_pw_tbx.Text;
            DialogResult result = DialogResult.None;

            // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
            if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
            {
                ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 입력 정보가 맞는 지 확인하는 팝업 띄움
            // 팝업에 Yes, No 버튼이 있음. No가 입력되면 다시 입력 창으로 되돌아감 
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

            // 모든 정보가 맞을 때, 게임 시작 패널로 넘어감
            if (result == DialogResult.Yes)
            {
                client.RequestSignIn(p1_username_tbx.Text, p1_pw_tbx.Text);
                islock=true;
                lock (locker)
                {
                    while (islock == true)
                    {
                        Monitor.Wait(locker);
                    }
                }
                if (message.Equals(p1_username_tbx.Text))
                {
                    p1_gameStart_btn.Invoke(new MethodInvoker(delegate { p1_gameStart_btn.Visible = true; }));
                    panel1_login_server.Invoke(new MethodInvoker(delegate { panel1_login_server.Visible = false; }));
                    panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = true; }));
                }
                else
                {
                    MessageBox.Show("Failed", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
        #endregion

        #region panel2_gameStart: 로그아웃, 게임시작 가능
        private void p1_gameStart_btn_Click(object sender, EventArgs e)
        {
            p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = false; }));
            panel1_login_server.Invoke(new MethodInvoker(delegate { panel1_login_server.Visible = false; }));
            panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = true; }));
        }

        /// <summary>
        /// 입력 받은 username을 가져와서 문구 출력
        /// </summary>
        private void panel2_gameStart_VisibleChanged(object sender, EventArgs e)
        {
            p2_welcome__label.Text = String.Format("{0} 님 환영합니다:)", p1_username_tbx.Text);
        }

        private void p2_gameStart_btn_Click(object sender, EventArgs e)
        {
            panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
            p3_title_label.Visible = true;
        }
        #endregion

        #region panel3_roomList: 방 리스트 (방 생성, 입장, 퇴장)
        private void panel3_roomList_VisibleChanged(object sender, EventArgs e)
        {
            p3_comein_label.Text = String.Format("{0} 님 접속 중", p1_username_tbx.Text);
            p3_roomname_tbx.Visible = false;
        }

        private void p3_makeRoom_btn_Click(object sender, EventArgs e)
        {
            p3_roomname_label.Visible = true;
            p3_roomname_label.Text = "생성 할 방 이름";
            p3_roomname_tbx.Visible = true;
            p3_roomname_tbx.Text = "";
            p3_create_btn.Visible = true;
            p3_people_label.Visible = true;
            p3_people_tbx.Visible = true;
            p3_people_tbx.Text = "";
        }


        List<string> serverRoomInfo;    // RoomList 함수가 서버로 부터 받아 온 방 정보를 사용하기 위함.

        // 서버에 존재하는 방 정보를 가져와서 방 리스트에 출력
        public override void RoomList(List<string> roomList)
        {
            p3_dataGridView1.Rows.Clear();    //새로 고침시, 셀 추가 문제 해결
            serverRoomInfo = roomList;

            foreach (string room in roomList)
            {
                string[] roomInfo = room.Split(',');
                string roomName = roomInfo[0];
                string playerCount = roomInfo[1];
                string roomMax = roomInfo[2];

                // 아무 정보도 없을 때 예외 처리 필요함
                p3_dataGridView1.Rows.Add(roomName, playerCount + '/' + roomMax);
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

        /// <summary>
        /// 방 생성하기 버튼 클릭 시 이벤트
        /// 방 이름과 최대 정원이 모두 입력되면 방 생성함
        /// </summary>
        private void p3_create_btn_Click(object sender, EventArgs e)
        {
            string roomName = p3_roomname_tbx.Text;
            string roomMax = p3_people_tbx.Text;

            if (roomName != string.Empty && roomMax != string.Empty)
            {
                int num = 0;
                try
                {
                    if (int.TryParse(p3_people_tbx.Text, out num))
                    {
                        client.RequestRoomCreate(roomName, roomMax);
                    }
                    panel3_roomList.Visible = false;
                    panel4_waitRoom.Visible = true;
                }
                catch (NullReferenceException nre)
                {
                    return;
                }
            }
        }



        int joinRes;     // 방 입장 시 정원 여부를 확인하기 위해 사용함.

        public override void RoomJoin(string result)
        {
            if (result.Equals("-1"))
            {
                joinRes = -1;
                ShowMessageBox("존재하지 않는 방입니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result.Equals("-2"))
            {
                joinRes = -2;
                ShowMessageBox("정원이 가득 찼습니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                joinRes = 0;
                client.RequestSendRoomChat("시스템", p1_username_tbx.Text + "이(가) 방에 참가함");
                ShowMessageBox(result + " 방에 참가완료", "Room Join", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
                //panel4_waitRoom.Invoke(new MethodInvoker(delegate { panel4_waitRoom.Visible = true; }));
                
            }
        }



        //테이블 내 입장하기 버튼 클릭 시
        void p3_dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)    
        {
            string rName = p3_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (rName != string.Empty)
            {
                client.RequestRoomJoin(rName);   // 서버에 방 이름 정보 보냄
                panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
                panel4_waitRoom.Invoke(new MethodInvoker(delegate { panel4_waitRoom.Visible = true; }));
            }
            
           
        }

        // 새로 고침 버튼 클릭 시 이벤트
        private void p3_refresh_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        // 뒤로 가기 버튼 클릭 시 이벤트
        private void p3_back_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
            p3_title_label.Visible = false;
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;
            panel3_roomList.Visible = false;
            panel2_gameStart.Visible = true;
        }

        #endregion


        #region panel4_waitRoom: 대기 방(채팅)

        // 접속자 리스트 - 아직 미완(사용자 별로 출력 차이 발생)
        public override void PlayerList(List<string> playerList)
        {
            p4_playerList.Items.Clear();
            playerList.ForEach(player =>
            {
                p4_playerList.Items.Add(player);
            });
        }

        public override void RoomChat(List<string> chatList)
        {
       
            p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.Text += chat + "\r\n"; }));
            });
        }

        private void p4_send_btn_Click(object sender, EventArgs e)
        {
            string content = p4_message_tbx.Text;
            client.username = p1_username_tbx.Text; 
            if (content != string.Empty)
            {
                client.RequestSendRoomChat(client.username, content);
                p4_message_tbx.Text = "";
            }
        }

        private void panel4_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            if(panel4_waitRoom.Visible == true)
            {
                foreach (string room in serverRoomInfo)
                {
                    string[] roomInfo = room.Split(',');
                    string roomName = roomInfo[0];
                    string playerCount = roomInfo[1];
                    string roomMax = roomInfo[2];
                    p4_roomInfo_label.Invoke(new MethodInvoker(delegate { string.Format("{0} 님 {1} 방 접속 중", p1_username_tbx.Text, roomName); }));
                    //p4_roomInfo_label.Text = string.Format("{0} 님 {1} 방 접속 중", p1_username_tbx.Text, roomName);
                }
            }
            else
            {
                p4_roomInfo_label.Visible = false;
            }

        }

        public override void RoomOut()
        {
            ShowMessageBox("방 나옴", "Room Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void p4_Out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            panel4_waitRoom.Visible = false;
            panel3_roomList.Visible = true;
        }

        private void p4_ready_btn_Click(object sender, EventArgs e)
        {
            p4_gameStart_btn.Visible = true;
        }

        #endregion

        private void p4_gameStart_btn_Click(object sender, EventArgs e)
        {
            panel4_waitRoom.Invoke(new MethodInvoker(delegate { panel4_waitRoom.Visible = false; }));
            panel5_Quest.Invoke(new MethodInvoker(delegate { panel5_Quest.Visible = true; }));
        }

        private void buzzer_Click(object sender, EventArgs e)
        {
            timer1.Start();
            client.RequestBuzzer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //시간 표시할 라벨
            //label1.Text=(int.Parse(label1.text)+1).ToString();
            //if (Label1.text == '5')
            {
                timer1.Stop();
               // client.RequestGuessAnswer(Textbox.Text);
               //답 읽어오기
            }
        }
    }
}