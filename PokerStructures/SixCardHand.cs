using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enumeration;
using PokerStructures.Enums;
using PokerStructures.ExtensionMethods;

namespace PokerStructures
{
    public class SixCardHand
    {
        public readonly List<Card> Hand;
        private readonly int[] _counters = new int[4];

        public SixCardHand(List<Card> cards)
        {
            Hand = cards;
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
            if (Hand[0].Rank == Hand[1].Rank &&
                Hand[4].Rank == Hand[5].Rank)
                return true;
            if (Hand[1].Rank == Hand[2].Rank &&
                Hand[3].Rank == Hand[4].Rank)
                return true;
            if (Hand[1].Rank == Hand[2].Rank &&
                Hand[4].Rank == Hand[5].Rank)
                return true;

            return false;
        }

        public bool HasThreePair()
        {
            if (Hand[0].Rank == Hand[1].Rank &&
                Hand[2].Rank == Hand[3].Rank &&
                Hand[4].Rank == Hand[5].Rank)
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
            if (Hand[3].Rank == Hand[4].Rank &&
                Hand[4].Rank == Hand[5].Rank)
                return true;
            return false;
        }

        public int CountOutsideRoyalFlushDraws()
        {
            if (Hand[2].Rank == Rank.Jack &&
                Hand[3].Rank == Rank.Queen &&
                Hand[4].Rank == Rank.King &&
                Hand[5].Rank == Rank.Ace)
            {
                if(Hand[2].Suit == Hand[3].Suit &&
                   Hand[3].Suit == Hand[4].Suit &&
                   Hand[4].Suit == Hand[5].Suit)
                return 1;
            }

            if (Hand[2].Rank == Rank.Ten &&
                Hand[3].Rank == Rank.Jack &&
                Hand[4].Rank == Rank.Queen &&
                Hand[5].Rank == Rank.King)
            {
                if (Hand[2].Suit == Hand[3].Suit &&
                   Hand[3].Suit == Hand[4].Suit &&
                   Hand[4].Suit == Hand[5].Suit)
                    return 1;
            }

            return 0;
        }

        public int CountInsideRoyalFlushDraws()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt(), Hand[5].ToInt()};

            foreach (var comb in PokerEnumerator.GetFourCardsFromSix(Hand))
            {
                if (comb[0].Rank == comb[3].Rank - 4 && !comb.HasPair() && comb.AreSameSuit() && comb.AreTenOrAbove())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt(), comb[3].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet.Count;
        }

        public int CountOutsideStraightFlushDraws()
        {
            if (Hand[5].Rank == Rank.Ace &&
                Hand[0].Rank == Rank.Two &&
                Hand[1].Rank == Rank.Three &&
                Hand[2].Rank == Rank.Four)
            {
                if(Hand[0].Suit == Hand[1].Suit &&
                   Hand[1].Suit == Hand[2].Suit && 
                   Hand[2].Suit == Hand[5].Suit)
                return 1;
            }

            if (Hand[2].Rank == Rank.Jack &&
                Hand[3].Rank == Rank.Queen &&
                Hand[4].Rank == Rank.King &&
                Hand[5].Rank == Rank.Ace)
            {
                if (Hand[0].Suit == Hand[1].Suit &&
                   Hand[1].Suit == Hand[2].Suit &&
                   Hand[2].Suit == Hand[5].Suit)
                    return 1;
            }

            for (int i = 0; i < 3; i++)
            {
                if (Hand[i].Rank == Hand[i + 1].Rank - 1 &&
                    Hand[i + 1].Rank == Hand[i + 2].Rank - 1 &&
                    Hand[i + 2].Rank == Hand[i + 3].Rank - 1)
                {
                    if (Hand[i].Suit == Hand[i + 1].Suit &&
                        Hand[i + 1].Suit == Hand[i + 2].Suit &&
                        Hand[i + 2].Suit == Hand[i + 3].Suit)
                    {
                        return 2;
                    }
                }
            }

            return 0;
        }

        public int CountInsideStraightFlushDraws()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt(), Hand[5].ToInt()};

            if (Hand[5].Rank == Rank.Ace && Hand[2].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2, 4).Except(handList));

            foreach (var comb in PokerEnumerator.GetFourCardsFromSix(Hand))
            {
                if (comb[0].Rank == comb[3].Rank - 4 && !comb.HasPair() && comb.AreSameSuit())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt(), comb[3].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet.Count;
        }

        public int CountOutsideStraightDraws()
        {
            if (Hand[2].Rank == Rank.Jack &&
                Hand[3].Rank == Rank.Queen &&
                Hand[4].Rank == Rank.King &&
                Hand[5].Rank == Rank.Ace)
                return 1;
            if (Hand[5].Rank == Rank.Ace &&
                Hand[0].Rank == Rank.Two &&
                Hand[1].Rank == Rank.Three &&
                Hand[2].Rank == Rank.Four)
                return 1;

            for (int i = 0; i < 3; i++)
            {
                if (Hand[i].Rank == Hand[i+1].Rank - 1 &&
                    Hand[i+1].Rank == Hand[i+2].Rank - 1 &&
                    Hand[i+2].Rank == Hand[i+3].Rank - 1)
                    return 2;
            }

            return 0;
        }

        public int CountInsideStraightDraws()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt(), Hand[5].ToInt() };

            if (Hand[5].Rank == Rank.Ace && Hand[2].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2,4).Except(handList));

            foreach (var comb in PokerEnumerator.GetFourCardsFromSix(Hand))
            {
                if (comb[0].Rank == comb[3].Rank - 4 && !comb.HasPair())
                {
                    var list = new List<int> {comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt(), comb[3].ToInt()};
                    if(comb[3].Rank == Rank.Ace)
                        list.Add(1);
                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet.Count;
        }
    }
}