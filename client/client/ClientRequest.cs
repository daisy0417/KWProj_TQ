using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public partial class Client
    {
        //클라이언트에서 서버에 보내는 요청들을 모아둠. 필요하다면 추가해서 사용할 수 있음.
        //형식은 "header", "content" 이고 Server에 chat_server에서 해당 내용을 처리 후
        //다시 응답을 보내주게 되고 그 후 Client의 ResponseProcess에서 응답에 따라 처리한다.
        public void RequestGetRoom()
        {
            SendRequest("GETROOM", "0");
        }

        public void RequestSetRoom(int newRoom)
        {
            SendRequest("SETROOM", newRoom.ToString());
        }

        public void RequestSignIn(string username, string password)
        {
            SendRequest("SIGNIN", username + ":" + password);
        }

        public void RequestSignUp(string username, string password)
        {
            SendRequest("SIGNUP", username + ":" + password);
        }

        public void RequestRoomList()
        {
            SendRequest("ROOMLIST", "0");
        }

        public void RequestRoomCreate(string roomName, string roomMax)
        {
            SendRequest("ROOMCREATE", roomName + "," + roomMax);
        }

        public void RequestRoomJoin(string roomName)
        {
            SendRequest("ROOMJOIN", roomName);
        }

        public void RequestRoomOut()
        {
            SendRequest("ROOMOUT", "0");
        }

        public void RequestSendRoomChat(string username, string content)
        {
            SendRequest("ROOMCHAT", username + ":" + content);
        }

        public void RequestPlayerList(string roomName)
        {
            SendRequest("PLAYERLIST", roomName);
        }

        public void RequestGameReady()
        {
            SendRequest("GAMEREADY", "0");
        }

        public void RequestReadyList()
        {
            SendRequest("READYLIST", "0");
        }

        public void RequestGameStart()
        {
            SendRequest("GAMESTART", "0");
        }

        public void RequestWordSelect(string word)
        {
            SendRequest("WORDSELECT", word);
        }

        public void RequestSendAnswer(string answer)
        {
            SendRequest("SENDANSWER", answer);
        }

        public void RequestSendQuestion(string question)
        {
            SendRequest("SENDQUESTION", question);
        }
        public void RequestGuessAnswer(string guess)
        {
            SendRequest("GUESSANSWER", guess);
        }
        public void RequestBuzzer()
        {
            SendRequest("BUZZER","0");
        }
    }
}
