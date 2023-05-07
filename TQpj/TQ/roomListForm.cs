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
    public partial class roomListForm : ClientForm
    {
        public roomListForm()
        {
            InitializeComponent();
        }
        public override void RoomList(List<string> roomList)
        {
            tbRoomList.Text = "";

            foreach (string room in roomList)
            {
                string[] roomInfo = room.Split(',');
                string roomName = roomInfo[0];
                string playerCount = roomInfo[1];
                string roomMax = roomInfo[2];

                tbRoomList.Text = tbRoomList.Text + string.Format("{0} - {1}/{2}\r\n", roomName, playerCount, roomMax);
            }
        }

        public override void RoomCreate(bool success)
        {
            if (success)
            {
                ShowMessageBox("방 생성 성공");
            }
            else
            {
                ShowMessageBox("방 생성 실패");
            }
        }

        public override void RoomJoin(string result)
        {
            if (result.Equals("-1"))
            {
                ShowMessageBox("존재하지 않는 방입니다.");
            }
            else if (result.Equals("-2"))
            {
                ShowMessageBox("정원이 가득 찼습니다.");
            }
            else
            {
                client.RequestSendRoomChat("시스템", client.username + "이(가) 방에 참가함");
                ShowMessageBox(result + " 방에 참가완료");
            }
        }

        public override void RoomOut()
        {
            ShowMessageBox("방 나옴");
        }

        private void mkRoomBtn_Click(object sender, EventArgs e)
        {
            mkRoomForm mkRF = new mkRoomForm();
            this.Hide();
            mkRF.ShowDialog();
            this.Close();
        }

        private void btnRefreshRoomList_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            string roomName = tbRoomName.Text;
            string roomMax = tbRoomCount.Text;

            if (roomName != string.Empty && roomMax != string.Empty)
            {
                int num = 0;
                if (int.TryParse(tbRoomCount.Text, out num))
                {
                    client.RequestRoomCreate(roomName, roomMax);
                }
            }
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string roomName = tbRoomName.Text;

            if (roomName != string.Empty)
            {
                client.RequestRoomJoin(roomName);
            }
        }

        private void btnOutRoom_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
        }

        private void roomListForm_Load(object sender, EventArgs e)
        {
            TryConnectServer();
        }
    }
}
