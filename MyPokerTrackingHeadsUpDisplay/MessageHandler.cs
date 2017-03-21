using System.Runtime.Remoting.Metadata.W3cXsd2001;
using PokerStructures;
using PokerStructures.Enums;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class MessageHandler
    {
        public delegate void UpdateHole(Card c, int pos);
        public delegate void UpdateBoard(Card c, int pos);
        public delegate void Raise();
        public delegate void Fold();
        public delegate void Call();
        public delegate void Bet();
        public delegate void Check();
        public delegate void SetHandNum(string num);
        public delegate void SetGameNum(string num);
        public delegate void SetHandHistoryState(string state);
        public delegate void SetHandWon();


        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;
        public event Raise RaiseEvent;
        public event Fold FoldEvent;
        public event Call CallEvent;
        public event Bet BetEvent;
        public event Check CheckEvent;
        public event SetHandNum SetHandNumEvent;
        public event SetGameNum SetGameNumEvent;
        public event SetHandHistoryState SetHandHistoryStateEvent;
        public event SetHandWon SetHandWonEvent;

        public string UserName { get; set; }
        private readonly Controller _controller;

        public MessageHandler()
        {
            _controller = Controller.Instance;
            _controller.MessageHandler = this;
            _controller.InitEvents();
        }

        public void ProcessUpdateBoardMessage(string message)
        {
            var splitMessage = message.Split(' ');

            var position = (int)char.GetNumericValue(splitMessage[2][1]);
            var card = CreateCardFromText(splitMessage[1]);

            UpdateBoardEvent?.Invoke(card, position);
        }

        public void ProcessUpdateHoleCardMessage(string message)
        {
            var splitMessage = message.Split(' ');

            var position = (int)char.GetNumericValue(splitMessage[1][0]);
            var card = CreateCardFromText(splitMessage[2]);

            UpdateHoleEvent?.Invoke(card, position);
        }

        public void HandleHandHistory(string handHistory)
        {
            foreach (var line in handHistory.Split('\n'))
            {
                if(line.Contains("HOLE") || line.Contains("FLOP") || line.Contains("TURN") ||
                   line.Contains("RIVER") || line.Contains("SHOW DOWN") || line.Contains("SUMMARY"))
                {
                    var split = line.Split(' ');
                    SetHandHistoryStateEvent?.Invoke(split[1]);
                }
                else if (line.Contains("SteMurphy131") && line.Contains("collected"))
                {
                    SetHandWonEvent?.Invoke();
                }
                else if (line.Contains("SteMurphy131"))
                {
                    if (line.Contains("calls"))
                    {
                        CallEvent?.Invoke();
                    }
                    else if (line.Contains("bets"))
                    {
                        BetEvent?.Invoke();
                    }
                    else if (line.Contains("raises"))
                    {
                        RaiseEvent?.Invoke();
                    }
                    else if (line.Contains("checks"))
                    {
                        CheckEvent?.Invoke();
                    }
                    else if (line.Contains("folds"))
                    {
                        FoldEvent?.Invoke();
                    }
                }
                else if (line.Contains("Hand #"))
                {
                    var split = line.Split(' ');
                    SetHandNumEvent?.Invoke(split[2]);
                }
            }
        }

        public void ProcessGameNumber(string gameNum)
        {
            var splitMessage = gameNum.Split(' ');
            SetGameNumEvent?.Invoke(splitMessage[1]);
        }

        public Card CreateCardFromText(string cardString)
        {
            var rankString = cardString.Substring(0, cardString.Length - 1);
            var suitString = cardString.Substring(cardString.Length - 1);

            Rank rank = (Rank)int.Parse(rankString);
            Suit suit = PokerHelper.SuitDictionary[suitString];

            return new Card(rank, suit);
        }
    }
}
