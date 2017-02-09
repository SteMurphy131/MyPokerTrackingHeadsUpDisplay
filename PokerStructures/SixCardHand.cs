using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PokerStructures.Enumeration;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class SixCardHand
    {
        private readonly List<Card> _hand;
        private readonly int[] _counters = new int[4];

        public SixCardHand(List<Card> cards)
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

        public bool HasTwoPair()
        {
            if (_hand[0].Rank == _hand[1].Rank &&
                _hand[2].Rank == _hand[3].Rank)
                return true;
            if (_hand[0].Rank == _hand[1].Rank &&
                _hand[3].Rank == _hand[4].Rank)
                return true;
            if (_hand[0].Rank == _hand[1].Rank &&
                _hand[4].Rank == _hand[5].Rank)
                return true;
            if (_hand[1].Rank == _hand[2].Rank &&
                _hand[3].Rank == _hand[4].Rank)
                return true;
            if (_hand[1].Rank == _hand[2].Rank &&
                _hand[4].Rank == _hand[5].Rank)
                return true;

            return false;
        }

        public bool HasThreePair()
        {
            if (_hand[0].Rank == _hand[1].Rank &&
                _hand[2].Rank == _hand[3].Rank &&
                _hand[4].Rank == _hand[5].Rank)
                return true;

            return false;
        }

        public bool HasThreeOfAKind()
        {
            if (_hand[0].Rank == _hand[1].Rank &&
                _hand[1].Rank == _hand[2].Rank)
                return true;
            if (_hand[1].Rank == _hand[2].Rank &&
                _hand[2].Rank == _hand[3].Rank)
                return true;
            if (_hand[2].Rank == _hand[3].Rank &&
                _hand[3].Rank == _hand[4].Rank)
                return true;
            if (_hand[3].Rank == _hand[4].Rank &&
                _hand[4].Rank == _hand[5].Rank)
                return true;
            return false;
        }

        public int CountOutsideRoyalFlushDraws()
        {
            if (_hand[2].Rank == Rank.Jack &&
                _hand[3].Rank == Rank.Queen &&
                _hand[4].Rank == Rank.King &&
                _hand[5].Rank == Rank.Ace)
            {
                if(_hand[2].Suit == _hand[3].Suit &&
                   _hand[3].Suit == _hand[4].Suit &&
                   _hand[4].Suit == _hand[5].Suit)
                return 1;
            }

            if (_hand[2].Rank == Rank.Ten &&
                _hand[3].Rank == Rank.Jack &&
                _hand[4].Rank == Rank.Queen &&
                _hand[5].Rank == Rank.King)
            {
                if (_hand[2].Suit == _hand[3].Suit &&
                   _hand[3].Suit == _hand[4].Suit &&
                   _hand[4].Suit == _hand[5].Suit)
                    return 1;
            }

            return 0;
        }

        public int CountInsideRoyalFlushDraws()
        {
            int count = (from comb in PokerEnumerator.GetFourCardsFromSix(_hand)
                             where comb[0].Rank == comb[3].Rank - 4
                             where  comb[0].Rank != comb[1].Rank && 
                                    comb[1].Rank != comb[2].Rank && 
                                    comb[2].Rank != comb[3].Rank
                             where comb[0].Rank == Rank.Ten || comb[3].Rank == Rank.Ace
                                select comb)
                                    .Count(comb =>  comb[0].Suit == comb[1].Suit && 
                                                    comb[1].Suit == comb[2].Suit && 
                                                    comb[2].Suit == comb[3].Suit);

            if (count == 3)
                count--;

            return count;
        }

        public int CountOutsideStraightFlushDraws()
        {
            if (_hand[5].Rank == Rank.Ace &&
                _hand[0].Rank == Rank.Two &&
                _hand[1].Rank == Rank.Three &&
                _hand[2].Rank == Rank.Four)
            {
                if(_hand[0].Suit == _hand[1].Suit &&
                   _hand[1].Suit == _hand[2].Suit && 
                   _hand[2].Suit == _hand[5].Suit)
                return 1;
            }

            for (int i = 0; i < 3; i++)
            {
                if (_hand[i].Rank == _hand[i + 1].Rank - 1 &&
                    _hand[i + 1].Rank == _hand[i + 2].Rank - 1 &&
                    _hand[i + 2].Rank == _hand[i + 3].Rank - 1)
                {
                    if (_hand[i].Suit == _hand[i + 1].Suit &&
                        _hand[i + 1].Suit == _hand[i + 2].Suit &&
                        _hand[i + 2].Suit == _hand[i + 3].Suit)
                    {
                        return 2;
                    }
                }
            }

            return 0;
        }

        public int CountInsideStraightFlushDraws()
        {
            int count = 0;

            if (_hand[5].Rank == Rank.Ace &&
                _hand[2].Rank == Rank.Five)
            {
                if (_hand[0].Suit == _hand[1].Suit &&
                   _hand[1].Suit == _hand[2].Suit &&
                   _hand[2].Suit == _hand[5].Suit)
                    count++;
            }

            count += PokerEnumerator.GetFourCardsFromSix(_hand)
                .Where(comb => comb[0].Rank == comb[3].Rank - 4)
                .Where(comb => comb[0].Rank != comb[1].Rank &&
                                comb[1].Rank != comb[2].Rank &&
                                comb[2].Rank != comb[3].Rank)
                    .Count(comb => comb[0].Suit == comb[1].Suit &&
                                    comb[1].Suit == comb[2].Suit &&
                                    comb[2].Suit == comb[3].Suit);

            if (count == 3)
                count--;
            return count;
        }

        public int CountOutsideStraightDraws()
        {
            if (_hand[2].Rank == Rank.Jack &&
                _hand[3].Rank == Rank.Queen &&
                _hand[4].Rank == Rank.King &&
                _hand[5].Rank == Rank.Ace)
                return 1;
            if (_hand[5].Rank == Rank.Ace &&
                _hand[0].Rank == Rank.Two &&
                _hand[1].Rank == Rank.Three &&
                _hand[2].Rank == Rank.Four)
                return 1;

            for (int i = 0; i < 3; i++)
            {
                if (_hand[i].Rank == _hand[i+1].Rank - 1 &&
                    _hand[i+1].Rank == _hand[i+2].Rank - 1 &&
                    _hand[i+2].Rank == _hand[i+3].Rank - 1)
                    return 2;
            }

            return 0;
        }

        public int CountInsideStraightDraws()
        {
            int count = 0;

            if (_hand[5].Rank == Rank.Ace &&
                _hand[2].Rank == Rank.Five)
                count++;

            count += PokerEnumerator.GetFourCardsFromSix(_hand)
                    .Where(comb => comb[0].Rank == comb[3].Rank - 4)
                        .Count(comb =>  comb[0].Rank != comb[1].Rank && 
                                        comb[1].Rank != comb[2].Rank && 
                                        comb[2].Rank != comb[3].Rank);

            if (count == 3)
                count--;
            return count;
        }
    }
}