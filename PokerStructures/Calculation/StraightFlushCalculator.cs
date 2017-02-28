using System;
using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enumeration;
using PokerStructures.Enums;
using PokerStructures.ExtensionMethods;

namespace PokerStructures.Calculation
{
    public static class StraightFlushCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            ISet<int> open = new HashSet<int>(), missingOne = new HashSet<int>(), missingTwo = new HashSet<int>();
            ISet<int> inside = new HashSet<int>(), outside = new HashSet<int>();
            var withoutPair = cards.RemovePairs();
            var handList = new List<int> { cards.Cards[0].ToInt(), cards.Cards[1].ToInt(), cards.Cards[2].ToInt(), cards.Cards[3].ToInt(), cards.Cards[4].ToInt() };

            if (cards.CountFlush() < 3)
                return PokerHelper.CreateTurnOuts(0, false);

            if (withoutPair.Count <= 2)
            {
                return PokerHelper.CreateTurnOuts(0, false);
            }
            if (withoutPair.Count == 3)
            {
                if(!withoutPair.AreSameSuit())
                    return PokerHelper.CreateTurnOuts(0, false);

                if (withoutPair[2].Rank == Rank.Ace && withoutPair[0].Rank <= Rank.Four)
                    withoutPair = new List<Card> { withoutPair[2], withoutPair[0], withoutPair[1] };
                open = PokerHelper.CountThreeOpenEnded(handList, withoutPair);
                missingOne = PokerHelper.CountThreeMissingOne(handList, withoutPair);
                missingTwo = PokerHelper.CountThreeMissingTwo(handList, withoutPair);

                return PokerHelper.RunnerRunnerSFlushOuts(open, missingOne, missingTwo);
            }
            if (withoutPair.Count == 4)
            {
                if (withoutPair.MaxSuit() < 3)
                    return PokerHelper.CreateTurnOuts(0, false);

                outside = PokerHelper.CountOutsideStraightDraws(handList, withoutPair);
                if (outside.Count > 0 && withoutPair.AreSameSuit())
                    return PokerHelper.CreateTurnOuts(outside.Count, false);

                inside = PokerHelper.CountInsideStraightDraws(handList, withoutPair);
                if (inside.Count > 0 && withoutPair.AreSameSuit())
                    return PokerHelper.CreateTurnOuts(inside.Count, false);

                if (withoutPair[3].Rank == Rank.Ace)
                {
                    var comb = new List<Card> { withoutPair[3], withoutPair[0], withoutPair[1] };
                    if (comb.AreSameSuit())
                    {
                        open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                        missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                        missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                    }
                }

                foreach (var comb in PokerEnumerator.GetThreeCardsFromFour(withoutPair).Where(comb => comb.AreSameSuit()))
                {
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }

                return PokerHelper.RunnerRunnerSFlushOuts(open, missingOne, missingTwo);
            }
            if (withoutPair.Count == 5)
            {
                if (withoutPair.MaxSuit() < 3)
                    return PokerHelper.CreateTurnOuts(0, false);

                //Four card collections
                if (withoutPair[4].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1], withoutPair[2] };
                    if (comb.AreSameSuit())
                    {
                        outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                        inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                    }
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromFive(withoutPair))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count);

                //Three card collections
                if (withoutPair[4].Rank == Rank.Ace)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1] };
                    if (comb.AreSameSuit())
                    {
                        open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                        missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                        missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                    }
                }

                foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(withoutPair).Where(comb => comb.AreSameSuit()))
                {
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }
                return PokerHelper.RunnerRunnerSFlushOuts(open, missingOne, missingTwo);
            }

            throw new ArgumentException("Without pair count should never be more than five");
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            ISet<int> inside = new HashSet<int>(),
                      outside = new HashSet<int>();

            var withoutPair = cards.RemovePairs();
            var handList = new List<int> { cards.Cards[0].ToInt(), cards.Cards[1].ToInt(), cards.Cards[2].ToInt(), cards.Cards[3].ToInt(), cards.Cards[4].ToInt(), cards.Cards[5].ToInt() };

            if (cards.CountFlush() < 4)
                return PokerHelper.CreateTurnOuts(0, false);

            if (withoutPair.Count <= 3)
            {
                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 4)
            {
                if (!withoutPair.AreSameSuit())
                    return PokerHelper.CreateTurnOuts(0, false);

                if (withoutPair[3].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                    withoutPair = new List<Card> { withoutPair[3], withoutPair[0], withoutPair[1], withoutPair[2] };

                outside = PokerHelper.CountOutsideStraightDraws(handList, withoutPair);
                if (outside.Count > 0)
                    return PokerHelper.CreateTurnOuts(outside.Count, false);

                inside = PokerHelper.CountInsideStraightDraws(handList, withoutPair);
                if (inside.Count > 0)
                    return PokerHelper.CreateTurnOuts(inside.Count, false);

                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 5)
            {
                if (withoutPair.MaxSuit() < 4)
                    return PokerHelper.CreateTurnOuts(0, false);

                if (withoutPair[4].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1], withoutPair[2] };

                    if (comb.AreSameSuit())
                    {
                        outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                        inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                    }
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromFive(withoutPair).Where(comb => comb.AreSameSuit()))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count);
                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 6)
            {
                if (withoutPair.MaxSuit() < 4)
                    return PokerHelper.CreateTurnOuts(0, false);

                if (withoutPair[5].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[5], withoutPair[0], withoutPair[1], withoutPair[2] };

                    if (comb.AreSameSuit())
                    {
                        outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                        inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                    }
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromSix(withoutPair).Where(comb => comb.AreSameSuit()))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count);
                return PokerHelper.CreateRiverOuts(0);
            }
            throw new ArgumentException("Without pair count should never be more than six");
        }
    }
}