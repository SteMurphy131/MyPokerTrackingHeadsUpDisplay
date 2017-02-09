﻿using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class FiveCardHand
    {
        public readonly List<Card> Hand;
        private readonly int[] _counters = new int[4];

        public FiveCardHand(IEnumerable<Card> cards)
        {
            Hand = cards.ToList();
        }

        public void Sort()
        {
            Hand.Sort();
        }

        public int CountFlush()
        {
            foreach (Card c in Hand)
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