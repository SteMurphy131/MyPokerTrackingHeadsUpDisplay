using System;
using System.Text;

namespace PokerStructures
{
    public class PokerHand
    {
        private Deck deck;
        private Card[] hand;

        public PokerHand(Deck deck)
        {
            this.deck = deck;
            hand = new Card[5];
        }

        public void pullCards()
        {
            for (int i = 0; i < 5; ++i)
                hand[i] = deck.pullCard();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in hand)
            {
                sb.Append(c);
                sb.Append(", ");
            }
            return sb.ToString();
        }

        public Card this[int index]
        {
            get
            {
                return hand[index];
            }
        }
        public void Sort()
        {
            Array.Sort(hand);
        }
    }
}