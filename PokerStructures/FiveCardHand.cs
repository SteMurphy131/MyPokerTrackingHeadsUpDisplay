using System;
using System.Collections.Generic;
using System.Linq;
using PokerStructures.Calculation;
using PokerStructures.Enumeration;
using PokerStructures.Enums;
using PokerStructures.ExtensionMethods;

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

        public bool HasPair()
        {
            if (Hand[0].Rank == Hand[1].Rank)
                return true;
            if (Hand[1].Rank == Hand[2].Rank)
                return true;
            if (Hand[2].Rank == Hand[3].Rank)
                return true;
            if (Hand[3].Rank == Hand[4].Rank)
                return true;

            return false;
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
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            foreach (var comb in PokerEnumerator.GetFourCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[3].Rank - 4 && !comb.HasPair())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt(), comb[3].ToInt() };
                    if (comb[3].Rank == Rank.Ace)
                        list.Add(1);

                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet.Count;
        }

        public bool HasEvenlySpacedCards()
        {
            if (HasPair())
                return false;

            return Hand[0].Rank == Hand[1].Rank - 2 &&
                   Hand[1].Rank == Hand[2].Rank - 2 &&
                   Hand[2].Rank == Hand[3].Rank - 2 &&
                   Hand[3].Rank == Hand[4].Rank - 2;
        }

        //TODO: sort out these
        public PokerScoreOuts RunnerRunnerStraightDraws()
        {
            var missingEnd = CountThreeOpenEndedJoinedCards();
            var missingOne = CountThreeCardMissingOneMiddle();
            var missingTwo = CountThreeCardMissingTwoMiddle();

            double percentage = 0;

            if (missingEnd.Count > 0)
            {
                switch (missingEnd.Count)
                {
                    case 2:
                        percentage += 1.48;
                        break;
                    case 3:
                        percentage += 2.96;
                        break;
                    case 4:
                        percentage += 4.44;
                        break;
                }
            }
            else if (missingOne.Count > 0)
            {
                if (missingTwo.Count > 0)
                {
                    missingOne.UnionWith(missingTwo);

                    if (missingOne.Count == 4)
                        percentage += 4.44;
                    else throw new ArgumentException("Unexpected value for missing one & missing two combined sets");
                }
                else
                {
                    switch (missingOne.Count)
                    {
                        case 2:
                            percentage += 1.48;
                            break;
                        case 3:
                            percentage += 2.96;
                            break;
                        case 4:
                            percentage += 4.44;
                            break;
                    }
                }
            }
            else if (missingTwo.Count > 0)
            {
                switch (missingTwo.Count)
                {
                    case 2:
                        percentage += 1.48;
                        break;
                    case 4:
                        percentage += 4.44;
                        break;
                }
            }

            return new PokerScoreOuts { Outs = 0, Percentage = percentage, RunnerRunner = true };
        }

        public ISet<int> CountThreeOpenEndedJoinedCards()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            if (Hand[0].Rank == Rank.Two && Hand[1].Rank == Rank.Three && Hand[4].Rank == Rank.Ace)
            {
                missing.Add(4);
                missing.Add(5);
            }

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank != comb[1].Rank - 1 || comb[1].Rank != comb[2].Rank - 1)
                    continue;

                if (comb[0].Rank >= Rank.Three && comb[2].Rank <= Rank.Queen)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 7).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Three && comb[2].Rank <= Rank.King)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 6).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Three && comb[2].Rank == Rank.Ace)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 4).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Two)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 1, 6).Except(handList));
                }
            }

            return new HashSet<int>(missing);
        }

        public ISet<int> CountThreeCardMissingOneMiddle()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            var combination = new List<Card> { Hand[4], Hand[0], Hand[1] };

            if (combination[0].Rank == Rank.Ace && !combination.HasPair() && combination[2].Rank == Rank.Four)
                missing.AddRange(Enumerable.Range(2, 4).Except(handList));

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 3 && !comb.HasPair())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };

                    if (list[2] == 14)
                        missing.AddRange(Enumerable.Range(list[0] - 1, 5).Except(handList));
                    else
                        missing.AddRange(Enumerable.Range(list[0] - 1, 6).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }

        public ISet<int> CountThreeCardMissingTwoMiddle()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            var combination = new List<Card> { Hand[4], Hand[0], Hand[1] };

            if (combination[0].Rank == Rank.Ace && !combination.HasPair() && combination[2].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2, 4).Except(handList));

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 4 && !comb.HasPair())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };

                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }

        public bool HasThreeOpenEndedJoinedCards()
        {
            return PokerEnumerator.GetThreeCardsFromFive(Hand)
                .Any(comb => comb[0].Rank == comb[1].Rank - 1 &&
                             comb[1].Rank == comb[2].Rank - 1 &&
                             comb[0].Rank >= Rank.Three &&
                             comb[2].Rank <= Rank.Queen);
        }

        public int CountOutsideRoyalFlushDraws()
        {
            if (Hand[1].Rank == Rank.Jack &&
                Hand[2].Rank == Rank.Queen &&
                Hand[3].Rank == Rank.King &&
                Hand[4].Rank == Rank.Ace)
            {
                if (Hand[1].Suit == Hand[2].Suit &&
                    Hand[2].Suit == Hand[3].Suit &&
                    Hand[3].Suit == Hand[4].Suit)
                    return 1;
            }

            if (Hand[1].Rank == Rank.Ten &&
                Hand[2].Rank == Rank.Jack &&
                Hand[3].Rank == Rank.Queen &&
                Hand[4].Rank == Rank.King)
            {
                if (Hand[1].Suit == Hand[2].Suit &&
                    Hand[2].Suit == Hand[3].Suit &&
                    Hand[3].Suit == Hand[4].Suit)
                    return 1;
            }

            return 0;
        }

        public int CountInsideRoyalFlushDraws()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt()};

            foreach (var comb in PokerEnumerator.GetFourCardsFromFive(Hand))
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
            if (Hand[4].Rank == Rank.Ace &&
                Hand[0].Rank == Rank.Two &&
                Hand[1].Rank == Rank.Three &&
                Hand[2].Rank == Rank.Four)
            {
                if (Hand[0].Suit == Hand[1].Suit &&
                    Hand[1].Suit == Hand[2].Suit &&
                    Hand[2].Suit == Hand[4].Suit)
                    return 1;
            }

            for (int i = 0; i < 2; i++)
            {
                if (Hand[i].Rank == Hand[i + 1].Rank - 1 &&
                    Hand[i + 1].Rank == Hand[i + 2].Rank - 1 &&
                    Hand[i + 2].Rank == Hand[i + 3].Rank - 1 &&
                    Hand.AreSameSuit())
                        return 2;
            }

            return 0;
        }

        public int CountInsideStraightFlushDraws()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt()};

            foreach (var comb in PokerEnumerator.GetFourCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[3].Rank - 4 && !comb.HasPair() && comb.AreSameSuit())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt(), comb[3].ToInt() };
                    if (comb[3].Rank == Rank.Ace)
                        list.Add(1);
                    missing.AddRange(Enumerable.Range(list[0], 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet.Count;
        }

        public PokerScoreOuts RunnerRunnerRoyalFlushDraws()
        {
            var missingEnd = CountThreeOpenEndedJoinedCardsRoyalFlush();
            var missingOne = CountThreeCardMissingOneMiddleRoyalFlush();
            var missingTwo = CountThreeCardMissingTwoMiddleRoyalFlush();

            double percentage = 0;

            if (missingEnd.Count > 0)
            {
                if (missingEnd.Count == 2)
                    percentage += .09;
                else 
                    throw new ArgumentException("Unexpected Value for open ended Royal Flush outs");
            }
            else if (missingOne.Count > 0)
            {
                if (missingOne.Count == 2)
                    percentage += .09;
                else 
                    throw new ArgumentException("Unexpected value for missing one royal flush outs");
            }
            else if (missingTwo.Count > 0)
            {
                if (missingTwo.Count == 2)
                    percentage += .09;
                else throw new ArgumentException("Unexpected value for missing two royal flush outs");
            }

            return new PokerScoreOuts { Outs = 0, Percentage = percentage, RunnerRunner = true };
        }

        public PokerScoreOuts RunnerRunnerStraightFlushDraws()
        {
            var missingEnd = CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = CountThreeCardMissingTwoMiddleStraightFlush();

            double percentage = 0;

            if (missingEnd.Count > 0)
            {
                switch (missingEnd.Count)
                {
                    case 2:
                        percentage += 0.09;
                        break;
                    case 3:
                        percentage += 0.19;
                        break;
                    case 4:
                        percentage += 0.28;
                        break;
                }
            }
            else if (missingOne.Count > 0)
            {
                if (missingTwo.Count > 0)
                {
                    missingOne.UnionWith(missingTwo);

                    if (missingOne.Count == 4)
                        percentage += 0.28;
                    else throw new ArgumentException("Unexpected value for missing one & missing two combined sets");
                }
                else
                {
                    switch (missingOne.Count)
                    {
                        case 2:
                            percentage += 0.09;
                            break;
                        case 3:
                            percentage += 0.19;
                            break;
                        case 4:
                            percentage += 0.28;
                            break;
                    }
                }
            }
            else if (missingTwo.Count > 0)
            {
                switch (missingTwo.Count)
                {
                    case 2:
                        percentage += 0.09;
                        break;
                    case 4:
                        percentage += 0.28;
                        break;
                }
            }

            return new PokerScoreOuts { Outs = 0, Percentage = percentage, RunnerRunner = true };
        }

        public ISet<int> CountThreeOpenEndedJoinedCardsStraightFlush()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            if (Hand[0].Rank == Rank.Two && Hand[1].Rank == Rank.Three && Hand[4].Rank == Rank.Ace)
            {
                missing.Add(4);
                missing.Add(5);
            }

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank != comb[1].Rank - 1 || comb[1].Rank != comb[2].Rank - 1 || !comb.AreSameSuit())
                    continue;

                if (comb[0].Rank >= Rank.Three && comb[2].Rank <= Rank.Queen)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 7).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Three && comb[2].Rank <= Rank.King)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 6).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Three && comb[2].Rank == Rank.Ace)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 2, 4).Except(handList));
                }
                else if (comb[0].Rank >= Rank.Two)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(list[0] - 1, 6).Except(handList));
                }
            }

            return new HashSet<int>(missing);
        }

        public ISet<int> CountThreeCardMissingOneMiddleStraightFlush()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            var combination = new List<Card> { Hand[4], Hand[0], Hand[1] };

            if (combination[0].Rank == Rank.Ace && !combination.HasPair() && combination[2].Rank == Rank.Four)
                missing.AddRange(Enumerable.Range(2, 4).Except(handList));

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 3 && !comb.HasPair() && comb.AreSameSuit())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };

                    if (list[2] == 14)
                        missing.AddRange(Enumerable.Range(list[0]-1, 5).Except(handList));
                    else if(list[0]-1 >= 10)
                        missing.AddRange(Enumerable.Range(list[0]-1,5).Except(handList));
                    else
                        missing.AddRange(Enumerable.Range(list[0] - 1, 6).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }

        public ISet<int> CountThreeCardMissingTwoMiddleStraightFlush()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            var combination = new List<Card> { Hand[4], Hand[0], Hand[1] };

            if (combination[0].Rank == Rank.Ace && !combination.HasPair() && combination[2].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2, 4).Except(handList));

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 4 && !comb.HasPair() && comb.AreSameSuit())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };

                    missing.AddRange(Enumerable.Range(list[0], 5).Except(list));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }

        public ISet<int> CountThreeOpenEndedJoinedCardsRoyalFlush()
        {
            var missing = new List<int>();
            var handList = new List<int>{Hand[0].ToInt(),Hand[1].ToInt(),Hand[2].ToInt(),Hand[3].ToInt(),Hand[4].ToInt()};

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank != comb[1].Rank - 1 || comb[1].Rank != comb[2].Rank - 1 || !comb.AreSameSuit() || !comb.AreTenOrAbove())
                    continue;

                if (comb[2].Rank <= Rank.Queen)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(10, 5).Except(handList));
                }
                else if (comb[2].Rank <= Rank.King)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(10, 5).Except(handList));
                }
                else if (comb[2].Rank == Rank.Ace)
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    missing.AddRange(Enumerable.Range(10, 5).Except(handList));
                }
            }

            return new HashSet<int>(missing);
        }

        public ISet<int> CountThreeCardMissingOneMiddleRoyalFlush()
        {
            var missing = new List<int>();
            var handList = new List<int> { Hand[0].ToInt(), Hand[1].ToInt(), Hand[2].ToInt(), Hand[3].ToInt(), Hand[4].ToInt() };

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 3 && !comb.HasPair() && comb.AreSameSuit() && comb.AreTenOrAbove())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };
                    if (comb[0].Rank == Rank.Ace)
                        list.Add(1);

                    missing.AddRange(Enumerable.Range(10, 5).Except(handList));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }

        public ISet<int> CountThreeCardMissingTwoMiddleRoyalFlush()
        {
            var missing = new List<int>();

            foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(Hand))
            {
                if (comb[0].Rank == comb[2].Rank - 4 && !comb.HasPair() && comb.AreSameSuit() && comb.AreTenOrAbove())
                {
                    var list = new List<int> { comb[0].ToInt(), comb[1].ToInt(), comb[2].ToInt() };

                    if (comb[0].Rank == Rank.Ace)
                        list.Add(1);

                    missing.AddRange(Enumerable.Range(10, 5).Except(list));
                }
            }

            var missingSet = new HashSet<int>(missing);
            return missingSet;
        }
    }
}