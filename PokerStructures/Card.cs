using System;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class Card : IComparable
    {
        private Rank _rank;
        private Suit _suit;

        public Rank Rank
        {
            get { return _rank; }
            set { _rank = Rank; }
        }

        public Suit Suit
        {
            get { return _suit; }
            set { _suit = Suit; }
        }

        // IComparable interface method
        public int CompareTo(object o)
        {
            if (o is Card)
            {
                Card c = (Card)o;
                if (_rank < c.Rank)
                    return -1;
                if (_rank > c.Rank)
                    return 1;
                return 0;
            }
            throw new ArgumentException("Object is not a Card");
        }

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }
        public Card() : this(Rank.None, Suit.None)
        {
        }

        public override string ToString()
        {
            return $"{_rank}{_suit}";
        }

        public bool IsJacksOrBetter()
        {
            if (_rank == Rank.Ace)
                return true;
            if (_rank >= Rank.Jack)
                return true;
            return false;
        }
    }
}