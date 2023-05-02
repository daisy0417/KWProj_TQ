using System.Collections.Generic;
using System.Net;

namespace GameLogic
{
    //아마 서버 프로그램에서만 쓰이게 될 것
    namespace Server
    {
        #region Data Class
        public class ChatMessage
        {
            private string senderName;
            public string SenderName { get { return senderName; } }
            private string message;
            public string Message { get { return message; } }

            public ChatMessage(string senderName, string message)
            {
                this.senderName = senderName;
                this.message = message;
            }
        }
        #endregion

        public class GameRoom
        {
            #region 변수
            private List<Player> playerList;
            private int maxPlayer;

            private Player hostPlayer;

            private Player currentPresenter;
            private Player currentQuestioner;
            private List<Player> questionerList;

            private List<ChatMessage> chatMessageList;

            private Player currentChallenger;

            private Category category;
            private string keyword;
            #endregion

            #region 초기화
            public GameRoom(Player hostPlayer, int maxPlayer)
            {
                this.hostPlayer = hostPlayer;
                this.maxPlayer = maxPlayer;

                this.currentPresenter = null;
                this.currentQuestioner = null;

                this.playerList = new List<Player> { hostPlayer };
                this.questionerList = new List<Player>();
                this.chatMessageList = new List<ChatMessage>();
            }

            public GameRoom()
            {
                this.hostPlayer = null;
                this.maxPlayer = 1;

                this.currentPresenter = null;
                this.currentQuestioner = null;

                this.playerList = new List<Player> { hostPlayer };
                this.questionerList = new List<Player>();
                this.chatMessageList = new List<ChatMessage>();
            }

            public void Init(Player hostPlayer, int maxPlayer)
            {
                this.hostPlayer = hostPlayer;
                this.maxPlayer = maxPlayer;

                this.currentPresenter = null;
                this.currentQuestioner = null;

                this.playerList = new List<Player> { hostPlayer };
                this.questionerList = new List<Player>();
                this.chatMessageList = new List<ChatMessage>();
            }
            #endregion

            #region 기본 동작

            public bool AddPlayer(Player newPlayer)
            {
                //방에 새로운 플레이어 입장
                if (playerList.Count == maxPlayer) return false;

                playerList.Add(newPlayer);

                return true;
            }

            public void AddChatMessage(string name, string content)
            {
                chatMessageList.Add(new ChatMessage(name, content));

                //클라이언트들에 해당 내용을 반영하게 업데이트를 요청
            }

            #endregion

            #region 게임 진행 : 정답 판별
            public bool Challenge(Player player)
            {
                if (currentChallenger == null) return false;

                currentChallenger = player;
                //다른 플레이어들 일시정지

                GiveChance();
                return true;
            }

            public void GiveChance()
            {
                //정답 도전자에게 정답 외칠 기회 주기
            }

            public bool ListenCorrect(string content)
            {
                if (keyword == content)
                {
                    //정답자에게 점수 주기

                    //다음 스테이지로
                    ResetStage();

                    return true;
                }
                else
                {
                    //다른 플레이어들 일시정지 풀기

                    return false;
                }
            }
            #endregion

            #region 게임 진행

            public bool GameStart()
            {
                //방에 사람들이 모두 들어오면 게임 시작
                if (playerList.Count != maxPlayer) return false;

                ResetStage();

                return true;
            }

            public void ResetStage()
            {
                //새로운 스테이지
                if (currentPresenter == null) currentPresenter = playerList[0];
                int index = playerList.FindIndex(p => p.Equals(currentPresenter)) + 1;
                if (index == playerList.Count)
                {
                    GameEnd();
                    return;
                }

                questionerList.Clear();
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (currentPresenter != playerList[i]) questionerList.Add(playerList[i]);
                }

                currentQuestioner = questionerList[0];
                AskQuestion();
            }

            public void GameEnd()
            {
                //게임 종료
            }

            public void NextQuestion()
            {
                //다음 질문자에게 질문 (0)
                int index = questionerList.FindIndex(p => p.Equals(currentQuestioner)) + 1;
                if (index == questionerList.Count) index = 0;

                currentQuestioner = questionerList[index];

                AskQuestion();
            }

            public void AskQuestion()
            {
                //질문창 활성화 (1)
                //SendQuestion();
            }

            public void SendQuestion(string content)
            {
                //질문 전송 (2)
                //클라이언트에서 질문 내용을 받음.
                AddChatMessage(currentQuestioner.Name, content);
                AskAnswer();
            }

            public void AskAnswer()
            {
                //답변창 활성화 (3)
                //SendAnswer();
            }

            public void SendAnswer(string content)
            {
                //답변 전송 후 다음 질문자에게로 (4)->(0)
                //클라이언틑에서 답변 내용을 받음
                AddChatMessage(currentPresenter.Name, content);
                NextQuestion();
            }

            #endregion
        }
    }

    namespace Client
    {

    }

    public class Player
    {
        private string name;
        public string Name { get { return name; } }
        private IPAddress address;
        public IPAddress Address { get { return address; } }

        public Player(string name, IPAddress address)
        {
            this.name = name;
            this.address = address;
        }

        public override int GetHashCode() => name.GetHashCode() ^ address.GetHashCode();
    }

    public enum Category
    {
        Animal, Food
    }
}