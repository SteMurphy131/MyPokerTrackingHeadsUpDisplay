using System;
using System.Collections.Generic;
using System.Linq;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace PokerStructures
{
    public static class PokerHelper
    {
        public static readonly Dictionary<string, Suit> SuitDictionary = new Dictionary<string, Suit>
        {
            {"d", Suit.Diamonds},
            {"h", Suit.Hearts},
            {"c", Suit.Clubs},
            {"s", Suit.Spades}
        };

        public static readonly Dictionary<int, Rank> RankDictionary = new Dictionary<int, Rank>
        {
            {2,  Rank.Two},
            {3,  Rank.Three},
            {4,  Rank.Four},
            {5,  Rank.Five},
            {6,  Rank.Six},
            {7,  Rank.Seven},
            {8,  Rank.Eight},
            {9,  Rank.Nine},
            {10, Rank.Ten},
            {11, Rank.Jack},
            {12, Rank.Queen},
            {13, Rank.King},
            {14, Rank.Ace}
        };

        public static PokerScoreOuts CreateRiverOuts(int outs)
        {
            double percentage = ((double)outs/46)*100;
            return new PokerScoreOuts {Outs = outs, Percentage = percentage, RunnerRunner = false};
        }

        public static PokerScoreOuts CreateTurnOuts(int outs, bool runner)
        {
            double percentage = (double)outs/47 * 100;
            return new PokerScoreOuts { Outs = outs, Percentage = percentage, RunnerRunner = runner};
        }

        public static HashSet<int> CountOutsideStraightDraws(List<int> hand, List<Card> cards)
        {
            if (cards[0].Rank == Rank.Jack && cards[1].Rank == Rank.Queen &&
                cards[2].Rank == Rank.King && cards[3].Rank == Rank.Ace)
                return new HashSet<int> { 10 };
            if (cards[0].Rank == Rank.Ace && cards[1].Rank == Rank.Two &&
                cards[2].Rank == Rank.Three && cards[3].Rank == Rank.Four)
                return new HashSet<int> { 5 };
            if (cards[0].Rank == cards[1].Rank - 1 &&
               cards[1].Rank == cards[2].Rank - 1 &&
               cards[2].Rank == cards[3].Rank - 1)
                return new HashSet<int>(Enumerable.Range(cards[0].ToInt() - 1, 6).Except(hand));

            return new HashSet<int>();
        }

        public static HashSet<int> CountInsideStraightDraws(List<int> hand, List<Card> cards)
        {
            var missing = new List<int>();

            if (cards[0].Rank == Rank.Ace && cards[3].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2, 4).Except(hand));

            if (cards[0].Rank == cards[3].Rank - 4)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt(), cards[3].ToInt() };
                if (cards[3].Rank == Rank.Ace)
                    list.Add(1);
                missing.AddRange(Enumerable.Range(list[0], 5).Except(hand));
            }
            return new HashSet<int>(missing);
        }

        public static HashSet<int> CountThreeOpenEnded(List<int> hand, List<Card> cards)
        {
            var missing = new List<int>();

            if (cards[0].Rank == Rank.Ace && cards[2].Rank == Rank.Three && cards[1].Rank == Rank.Two)
            {
                missing.AddRange(Enumerable.Range(2, 4).Except(hand));
                return new HashSet<int>(missing);
            }
            else if (cards[0].Rank != cards[1].Rank - 1 || cards[1].Rank != cards[2].Rank - 1)
                return new HashSet<int>();

            if (cards[0].Rank >= Rank.Three && cards[2].Rank <= Rank.Queen)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };
                missing.AddRange(Enumerable.Range(list[0] - 2, 7).Except(hand));
            }
            else if (cards[0].Rank >= Rank.Three && cards[2].Rank <= Rank.King)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };
                missing.AddRange(Enumerable.Range(list[0] - 2, 6).Except(hand));
            }
            else if (cards[0].Rank >= Rank.Three && cards[2].Rank == Rank.Ace)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };
                missing.AddRange(Enumerable.Range(list[0] - 2, 4).Except(hand));
            }
            else if (cards[0].Rank >= Rank.Two)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };
                missing.AddRange(Enumerable.Range(list[0] - 1, 6).Except(hand));
            }

            return new HashSet<int>(missing);
        }

        public static HashSet<int> CountThreeMissingOne(List<int> hand, List<Card> cards)
        {
            var missing = new List<int>();
            if (cards[0].Rank == Rank.Ace && cards[2].Rank == Rank.Four)
                missing.AddRange(Enumerable.Range(2, 4).Except(hand));

            if (cards[0].Rank == cards[2].Rank - 3)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };

                missing.AddRange(list[2] == 14
                    ? Enumerable.Range(list[0] - 1, 5).Except(hand)
                    : Enumerable.Range(list[0] - 1, 6).Except(hand));
            }

            return new HashSet<int>(missing);
        }

        public static HashSet<int> CountThreeMissingTwo(List<int> hand, List<Card> cards)
        {
            var missing = new List<int>();
            if (cards[0].Rank == Rank.Ace && cards[2].Rank == Rank.Five)
                missing.AddRange(Enumerable.Range(2, 4).Except(hand));

            if (cards[0].Rank == cards[2].Rank - 4)
            {
                var list = new List<int> { cards[0].ToInt(), cards[1].ToInt(), cards[2].ToInt() };
                missing.AddRange(Enumerable.Range(list[0], 5).Except(hand));
            }

            return new HashSet<int>(missing);
        }

        public static PokerScoreOuts RunnerRunnerOuts(ISet<int> open, ISet<int> one, ISet<int> two)
        {
            double percentage = 0;

            if (open.Count > 0)
            {
                switch (open.Count)
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
            else if (one.Count > 0)
            {
                if (two.Count > 0)
                {
                    one.UnionWith(two);

                    if (one.Count == 4)
                        percentage += 4.44;
                    else throw new ArgumentException("Unexpected value for missing one & missing two combined sets");
                }
                else
                {
                    switch (one.Count)
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
            else if (two.Count > 0)
            {
                switch (two.Count)
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

        public static PokerScoreOuts RunnerRunnerSFlushOuts(ISet<int> open, ISet<int> one, ISet<int> two)
        {
            double percentage = 0;

            if (open.Count > 0)
            {
                switch (open.Count)
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
            else if (one.Count > 0)
            {
                if (two.Count > 0)
                {
                    one.UnionWith(two);

                    if (one.Count == 4)
                        percentage += 0.28;
                    else throw new ArgumentException("Unexpected value for missing one & missing two combined sets");
                }
                else
                {
                    switch (one.Count)
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
            else if (two.Count > 0)
            {
                switch (two.Count)
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
    }
}