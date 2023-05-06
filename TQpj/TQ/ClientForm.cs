using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQ
{
    public class ClientForm : Form
    {
        protected Client client;

        /// <summary>
        ///  RequestGetRoom 호출 후 도착하는 응답. 현재 접속중인 room을 확인한다. override 필요
        /// </summary>
        public virtual void ViewRoom(int room)
        {

        }

        /// <summary>
        ///  RequestSignIn 호출 후 도착하는 응답. 로그인을 시도한 후 username을 통해 성공하면 계정 아이디, 실패하면 빈 문자열을 전달한다. override 필요
        /// </summary>
        public virtual void SignIn(string username)
        {

        }

        /// <summary>
        ///  RequestSignUp 호출 후 도착하는 응답. 서버에 새로운 계정 정보를 추가한 후 sucess로 회원가입 성공 여부를 알려준다. override 필요
        /// </summary>
        public virtual void SignUp(bool success)
        {

        }

        /// <summary>
        ///  RequestRoomList 호출 후 도착하는 응답. 현재 서버에 존재하는 방의 정보를 roomList로 전달한다. ','로 구분되어 방 이름, 현재 방 인원, 방의 최대 인원이 담겨있다. override 필요
        /// </summary>
        public virtual void RoomList(List<string> roomList)
        {

        }

        /// <summary>
        ///  RequestRoomCreate 호출 후 도착하는 응답. 서버에 새로운 방을 생성한 후 성공 여부를 success로 알려준다. override 필요
        /// </summary>
        public virtual void RoomCreate(bool success)
        {

        }

        /// <summary>
        ///  RequestRoomJoin 호출 후 도착하는 응답. 서버에 있는 방에 참가한 후 result를 통해 방이 없으면 -1, 정원이 가득 찼으면 -2, 성공하면 방의 이름을 전달한다. override 필요
        /// </summary>
        public virtual void RoomJoin(string result)
        {

        }

        /// <summary>
        ///  RequestRoomOut 호출 후 도착하는 응답. 현재 참가중인 방에서 나온다. override 필요
        /// </summary>
        public virtual void RoomOut()
        {

        }

        /// <summary>
        ///  RequestSendRoomChat 호출 후 도착하는 응답. 메세지를 보낸 후 chatList를 통해 해당 메세지가 포함된 채팅 목록을 전달한다. 계정명과 채팅 내용이 ':'로 구분되어 있다. override 필요
        /// </summary>
        public virtual void RoomChat(List<string> chatList)
        {

        }

        /// <summary>
        ///  MessageBox를 보여준다. override 불필요
        /// </summary>
        public void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }


        /// <summary>
        ///  서버에 접속을 시도한다. 이때 client도 자동으로 생성된다. client를 통해 서버에 요청을 보낼 수 있다. override 불필요
        /// </summary>
        protected void TryConnectServer()
        {
            if (client == null) client = new Client(this);

            if (client.Activate)
            {
                ShowMessageBox("이미 접속중");
            }
            else
            {
                client.Start();
            }
        }
    }
}
