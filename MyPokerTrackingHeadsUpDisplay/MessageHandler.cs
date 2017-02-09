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

        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;
        public event Raise RaiseEvent;
        public event Fold FoldEvent;

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

        public void HandleRaise()
        {
            RaiseEvent?.Invoke();
        }

        public void HandleFold()
        {
            FoldEvent?.Invoke();
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
