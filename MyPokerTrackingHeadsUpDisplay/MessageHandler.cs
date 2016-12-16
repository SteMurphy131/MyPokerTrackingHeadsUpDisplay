using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class MessageHandler
    {
        public delegate void UpdateHole(Card c, int pos);

        public delegate void UpdateBoard(Card c, int pos);

        public event UpdateHole updateHole;
        public event UpdateBoard updateBoard;
        private Controller _controller;

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

            updateBoard?.Invoke(card, position);
        }

        public void ProcessUpdateHoleCardMessage(string message)
        {
            var splitMessage = message.Split(' ');

            var position = (int)char.GetNumericValue(splitMessage[1][0]);
            var card = CreateCardFromText(splitMessage[2]);

            updateHole?.Invoke(card, position);
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
