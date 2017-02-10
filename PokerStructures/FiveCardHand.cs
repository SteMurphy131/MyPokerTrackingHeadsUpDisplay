using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enumeration;
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

        public bool HasTwoPair()
        {
            if (Hand[0].Rank == Hand[1].Rank &&
                Hand[2].Rank == Hand[3].Rank)
                return true;
            if (Hand[0].Rank == Hand[1].Rank &&
                Hand[3].Rank == Hand[4].Rank)
                return true;
            if (Hand[1].Rank == Hand[2].Rank &&
                Hand[3].Rank == Hand[4].Rank)
                return true;
            return false;
        }

        public bool HasThreeOfAKind()
        {
            if (Hand[0].Rank == Hand[1].Rank &&
                Hand[1].Rank == Hand[2].Rank)
                return true;
            if (Hand[1].Rank == Hand[2].Rank &&
                Hand[2].Rank == Hand[3].Rank)
                return true;
            if (Hand[2].Rank == Hand[3].Rank &&
                Hand[3].Rank == Hand[4].Rank)
                return true;
            return false;
        }

        public int CountOutsideStraightDraws()
        {
            if (Hand[1].Rank == Rank.Jack &&
                Hand[2].Rank == Rank.Queen &&
                Hand[3].Rank == Rank.King &&
                Hand[4].Rank == Rank.Ace)
                return 1;
            if (Hand[4].Rank == Rank.Ace &&
                Hand[0].Rank == Rank.Two &&
                Hand[1].Rank == Rank.Three &&
                Hand[2].Rank == Rank.Four)
                return 1;

            for (int i = 0; i < 2; i++)
            {
                if (Hand[i].Rank == Hand[i + 1].Rank - 1 &&
                    Hand[i + 1].Rank == Hand[i + 2].Rank - 1 &&
                    Hand[i + 2].Rank == Hand[i + 3].Rank - 1)
                    return 2;
            }

            return 0;
        }

        public int CountInsideStraightDraws()
        {
            int count = 0;

            if (Hand[4].Rank == Rank.Ace &&
                Hand[2].Rank == Rank.Five)
                count++;

            count += PokerEnumerator.GetFourCardsFromFive(Hand)
                    .Where(comb => comb[0].Rank == comb[3].Rank - 4)
                        .Count(comb => comb[0].Rank != comb[1].Rank &&
                                        comb[1].Rank != comb[2].Rank &&
                                        comb[2].Rank != comb[3].Rank);

            if (count == 3)
                count--;
            return count;
        }
    }
}