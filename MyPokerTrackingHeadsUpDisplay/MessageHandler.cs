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
        public delegate void SetHandNum(string num);
        public delegate void SetGameNum(string num);
        public delegate void SetHandHistoryState(string state);
        public delegate void SetHandWon();


        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;
        public event Raise RaiseEvent;
        public event Fold FoldEvent;
        public event SetHandNum SetHandNumEvent;
        public event SetGameNum SetGameNumEvent;
        public event SetHandHistoryState SetHandHistoryStateEvent;
        public event SetHandWon SetHandWonEvent;

        public string UserName { get; set; }

        public MessageHandler()
        {
            var controller = Controller.Instance;
            controller.MessageHandler = this;
            controller.InitEvents();
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

        public void ProcessRaise()
        {
            RaiseEvent?.Invoke();
        }

        public void ProcessFold()
        {
            FoldEvent?.Invoke();
        }

        public void ProcessHandNumber(string handNum)
        {
            var splitMessage = handNum.Split(' ');
            SetHandNumEvent?.Invoke(splitMessage[2]);
        }

        public void ProcessGameNumber(string gameNum)
        {
            var splitMessage = gameNum.Split(' ');
            SetGameNumEvent?.Invoke(splitMessage[1]);
        }

        public void ProcessHandHistoryState(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);

            var splitMessage = message.Split(' ');
            SetHandHistoryStateEvent?.Invoke(splitMessage[1]);
        }

        public void ProcessHandWon(string message)
        {
            SetHandWonEvent?.Invoke();
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
