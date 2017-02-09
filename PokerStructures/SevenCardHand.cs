using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class SevenCardHand
    {
        private readonly List<Card> _hand;
        private readonly int[] _counters = new int[4];

        public SevenCardHand(List<Card> cards)
        {
            _hand = cards;
        }

        public void Sort()
        {
            _hand.Sort();
        }

        public int CountFlush()
        {
            foreach (Card c in _hand)
            {
                switch (c.Suit)
                {
                    case Suit.Clubs:
                        _counters[0]++;
                        break;
                    case Suit.Hearts:
                        _counters[1]++;
                        break;
                    case Suit.Diamonds:
                        _counters[2]++;
                        break;
                    case Suit.Spades:
                        _counters[3]++;
                        break;
                }
            }
            return _counters.Max();
        }
    }
}