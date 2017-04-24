using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enums;
using PokerStructures.Interfaces;

namespace PokerStructures
{
    public abstract class Hand : IHand
    {
        public List<Card> Cards;
        private readonly Dictionary<Suit, int> _counters = new Dictionary<Suit, int>
        {
            {Suit.Clubs, 0},
            {Suit.Hearts, 0},
            {Suit.Diamonds, 0},
            {Suit.Spades, 0}
        };

        private Suit _maxSuit = 0;

        public void Sort()
        {
            Cards.Sort();
        }

        public int CountFlush()
        {
            foreach (Card c in Cards)
            {
                switch (c.Suit)
                {
                    case Suit.Clubs:
                        _counters[Suit.Clubs]++;
                        break;
                    case Suit.Hearts:
                        _counters[Suit.Hearts]++;
                        break;
                    case Suit.Diamonds:
                        _counters[Suit.Diamonds]++;
                        break;
                    case Suit.Spades:
                        _counters[Suit.Spades]++;
                        break;
                }
            }

            int val = _counters.Values.Max();
            _maxSuit = CalculateMaxSuit(val);
            foreach (var key in _counters.Keys.ToList())
                _counters[key] = 0;
            return val;
        }

        public Suit CalculateMaxSuit(int max)
        {
            if (_counters[Suit.Clubs] == max)
                return Suit.Clubs;
            if (_counters[Suit.Hearts] == max)
                return Suit.Hearts;
            if (_counters[Suit.Diamonds] == max)
                return Suit.Diamonds;
            return Suit.Spades;
        }

        public Suit GetMaxSuit()
        {
            return _maxSuit;
        }
    }
}