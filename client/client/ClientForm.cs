using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
        
        public ClientForm()
        {
            //this.SuspendLayout();
            InitializeComponent();
        }
        
        protected Client client;

        /// <summary>
        ///  RequestGetRoom 호출 후 도착하는 응답. 현재 접속중인 room을 확인한다. override 필요
        /// </summary>
        public virtual void ViewRoom(int room)
        {

        }

        /// <summary>
        /// RequestSendFriendRequest 호출 후 도착하는 응답. 친구 요청의 성공 여부를 전달한다. 
        /// success가 false인 경우 사용자가 오프라인이거나, 아예 없는 사용자라는 것 override 필요
        /// </summary>
        public virtual void SendFriendRequest(bool success)
        {
            /*
             * if(success == false) 사용자를 찾을 수 없습니다.
             */
        }

        /// <summary>
        /// RequestSendFriendRequest 호출 후 상대에게 도착하는 응답. username(상대)가 보낸 친구 요청을 수락할 것인지 묻는다.
        /// 수락을 선택한다면 RequestAcceptFriend 호출해야함 override 필요
        /// </summary>
        public virtual void FriendRequest(string username)
        {
            /*
             * 다이얼로그로 물어본 후 OK 선택하면 RequestAcceptFriend(username)
             */
        }

        /// <summary>
        /// RequestAcceptFriend 호출 후 도착하는 응답. 친구 요청의 성공 여부를 전달한다. 
        /// success가 false인 경우 사용자가 오프라인이거나, 아예 없는 사용자라는 것 override 필요
        /// </summary>
        public virtual void AcceptFriend(bool success)
        {
            /*
             * if(success == false) 사용자를 찾을 수 없습니다.
             */
        }

        /// <summary>
        /// RequestFriendList 호출 후 도착하는 응답. 친구들의 username을 담은 List를 전달한다. 없으면 빈 리스트 override 필요
        /// </summary>
        public virtual void FriendList(List<string> friendList)
        {

        }

        /// <summary>
        /// RequestJoinFriendRoom 호출  override 필요
        /// </summary>
        public virtual void JoinFriendRoom(int flag)
        {
            /*
             * if(flag == -1) 친구가 참가중인 방이 없습니다.
             * else if(flag == -2) 친구의 방이 이미 게임중입니다.
             * else if(flag == -3) 친구의 방이 가득 찼습니다.
             * 
             * 아무런 응답이 오지 않으면 성공했다는 것. 서버에서 자동으로 RoomJoin을 호출함.
             */
        }

        /// <summary>
        ///  RequestSignIn 호출 후 도착하는 응답. 로그인을 시도한 후 
        ///  username을 통해 성공하면 계정 아이디, 실패하면 빈 문자열을 전달한다. override 필요
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
        ///  RequestSignOut 호출 후 도착하는 응답. 다시 로그인 화면으로 돌아가도록 해주면 됨. override 필요
        /// </summary>
        public virtual void SignOut()
        {

        }

        /// <summary>
        ///  RequestRoomList 호출 후 도착하는 응답. 현재 서버에 존재하는 방의 정보를 roomList로 전달한다. 
        ///  ','로 구분되어 방 이름, 현재 방 인원, 방의 최대 인원이 담겨있다. override 필요
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
        ///  RequestRoomJoin 호출 후 도착하는 응답. 서버에 있는 방에 참가한 후 
        ///  result를 통해 방이 없으면 -1, 정원이 가득 찼으면 -2, 성공하면 방의 이름을 전달한다. override 필요
        /// </summary>
        public virtual void RoomJoin(string result)
        {

        }
        public virtual void RoomJoinRejected() { }
        /// <summary>
        ///  RequestRoomOut 호출 후 도착하는 응답. 현재 참가중인 방에서 나온다. override 필요
        /// </summary>
        public virtual void RoomOut()
        {

        }
        public virtual void Kicked() { }
        /// <summary>
        ///  RequestSendRoomChat 호출 후 도착하는 응답. 메세지를 보낸 후 chatList를 통해 해당 메세지가 포함된 채팅 목록을 전달한다. 
        ///  계정명과 채팅 내용이 ':'로 구분되어 있다. override 필요
        /// </summary>
        public virtual void RoomChat(List<string> chatList)
        {

        }

        /// <summary>
        ///  RequestPlayerList 호출 후 도착하는 응답. 현재 방에 존재하는 플레이어의 username 목록을 playerList로 전달한다. 
        ///  해당 방에 플레이어가 진입할때 기존에 있던 다른 플레이어들에게 자동으로 호출되어 방의 인원 변경을 자동으로 반영하게 함. override 필요
        /// </summary>
        public virtual void PlayerList(List<string> playerList)
        {

        }

        /// <summary>
        ///  RequestGameStart 호출 후 도착하는 응답. 실패했을 경우에만 호출되며 성공했을 경우에는 PresenterChoice가 호출될 것이다.
        /// </summary>
        public virtual void GameStartFail()
        {

        }

        /// <summary>
        /// 강제로 게임이 종료되면 도착하는 응답.
        /// </summary>
        public virtual void ForceGameOver(int flag)
        {

        }

        /// <summary>
        ///  RequestGameReady 호출 후 도착하는 응답. 현재 준비 여부를 전달한다.
        /// </summary>
        public virtual void GameReady(bool ready)
        {

        }

        /// <summary>
        ///  RequestReadyList 호출 후 도착하는 응답. 현재 준비 완료된 플레이어들의 username 리스트를 전달한다.
        /// </summary>
        public virtual void ReadyList(List<string> readyList)
        {

        }

        /// <summary>
        /// 질문자가 바뀔때 자동으로 호출되는 응답. 현재 질문자의 username을 전달한다.
        /// </summary>
        public virtual void CurrentQuestioner(string username)
        {

        }

        public virtual void SetBcount(int count) { }
        public virtual void RefreshWins(string wins_arr) { }
        public virtual void Ranking(string rank_arr) { }

        #region 게임 진행에 따른 화면들
        /// <summary>
        /// 방장의 게임 시작 전 화면. 게임 시작 버튼, 강퇴 버튼 등 방장의 고유한 권한이 있는 화면
        /// </summary>
        public virtual void OwnerWait()
        {
            
        }

        /// <summary>
        /// 참가자의 게임 시작 전 화면. 방장의 고유한 권한을 제외하고, 준비버튼등만 활성화
        /// </summary>
        public virtual void PlayerWait()
        {

        }

  

        /// <summary>
        /// 게임 시작 후 출제자가 제시어를 정하는 화면 RequestWordSelect() 요청을 보낼 수 있는 버튼이 존재해야한다.
        /// </summary>
        public virtual void PresenterChoice()
        {

        }

        /// <summary>
        /// 게임 시작 후 출제자가 질문을 기다리는 화면.
        /// </summary>
        public virtual void PresenterWait()
        {

        }

        /// <summary>
        /// 게임 시작 후 출제자가 질문에 대한 답변을 작성하는 화면. RequestSendAnswer() 요청을 보낼 수 있는 버튼이 존재해야한다.
        /// </summary>
        public virtual void PresenterAnswer()
        {

        }

        /// <summary>
        /// 게임 시작 후 질문자가 질문을 기다리는 화면.
        /// </summary>
        public virtual void QuestionerWait()
        {

        }

        /// <summary>
        /// 게임 시작 후 질문자가 질문을 작성하는 화면. RequestSendQuestion() 요청을 보낼 수 있는 버튼이 존재해야한다.
        /// </summary>
        public virtual void QuestionerQuestion()
        {

        }

        public virtual void LockByBuzzer() { }
        public virtual void UnlockByBuzzer() { }
        #endregion

        /// <summary>
        ///  MessageBox를 보여준다. override 불필요
        /// </summary>
        public void ShowMessageBox(string msg,string caption,MessageBoxButtons btn, MessageBoxIcon icon)
        {
            MessageBox.Show(msg, caption, btn, icon);
        }


        /// <summary>
        ///  서버에 접속을 시도한다. 이때 client도 자동으로 생성된다. client를 통해 서버에 요청을 보낼 수 있다. override 불필요
        /// </summary>
        protected void TryConnectServer(string serverIP)
        {
            if(client == null) client = new Client(this, serverIP);

            if (client.Activate)
            {
                ShowMessageBox("이미 접속중", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                client.ServerIP = IPAddress.Parse(serverIP);
                client.Start();
            }
        }

        /// <summary>
        ///  TryConnectServer 호출 후 도착하는 응답. success를 통해 서버 연결 성공 여부를 전달한다. override 필요
        /// </summary>
        public virtual void ConnectServerResult(bool success)
        {

        }
    }
}
