using System;
using System.Collections.Generic;
using PokerStructures.Enumeration;
using PokerStructures.Enums;
using PokerStructures.ExtensionMethods;

namespace PokerStructures.Calculation
{
    public static class StraightCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            ISet<int> open = new HashSet<int>(), 
                      missingOne = new HashSet<int>(), 
                      missingTwo = new HashSet<int>(),
                      inside = new HashSet<int>(), 
                      outside = new HashSet<int>();

            var withoutPair = cards.RemovePairs();
            var handList = new List<int> { cards.Cards[0].ToInt(), cards.Cards[1].ToInt(), cards.Cards[2].ToInt(), cards.Cards[3].ToInt(), cards.Cards[4].ToInt() };
            
            if (withoutPair.Count <= 2)
            {
                return PokerHelper.CreateTurnOuts(0, true);
            }
            if (withoutPair.Count == 3)
            {
                if (withoutPair[2].Rank == Rank.Ace && withoutPair[0].Rank <= Rank.Four)
                    withoutPair = new List<Card> { withoutPair[2], withoutPair[0], withoutPair[1] };
                open = PokerHelper.CountThreeOpenEnded(handList, withoutPair);
                missingOne = PokerHelper.CountThreeMissingOne(handList, withoutPair);
                missingTwo = PokerHelper.CountThreeMissingTwo(handList, withoutPair);

                return PokerHelper.RunnerRunnerOuts(open, missingOne, missingTwo);
            }
            if (withoutPair.Count == 4)
            {
                outside = PokerHelper.CountOutsideStraightDraws(handList, withoutPair);
                if (outside.Count > 0)
                    return PokerHelper.CreateTurnOuts(outside.Count*4, false);

                inside = PokerHelper.CountInsideStraightDraws(handList, withoutPair);
                if (inside.Count > 0)
                    return PokerHelper.CreateTurnOuts(inside.Count*4, false);

                if (withoutPair[3].Rank == Rank.Ace)
                {
                    var comb = new List<Card> {withoutPair[3], withoutPair[0], withoutPair[1]};
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }

                foreach (var comb in PokerEnumerator.GetThreeCardsFromFour(withoutPair))
                {
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }

                return PokerHelper.RunnerRunnerOuts(open, missingOne, missingTwo);
            }
            if (withoutPair.Count == 5)
            {
                //Four card collections
                if (withoutPair[4].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1], withoutPair[2] };

                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    if (outside.Count > 0)
                        return PokerHelper.CreateTurnOuts(outside.Count * 4, false);

                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                    if (inside.Count > 0)
                        return PokerHelper.CreateTurnOuts(inside.Count * 4, false);
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromFive(withoutPair))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count * 4);

                //Three card collections
                if (withoutPair[4].Rank == Rank.Ace)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1] };
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }

                foreach (var comb in PokerEnumerator.GetThreeCardsFromFive(withoutPair))
                {
                    open.UnionWith(PokerHelper.CountThreeOpenEnded(handList, comb));
                    missingOne.UnionWith(PokerHelper.CountThreeMissingOne(handList, comb));
                    missingTwo.UnionWith(PokerHelper.CountThreeMissingTwo(handList, comb));
                }

                return PokerHelper.RunnerRunnerOuts(open, missingOne, missingTwo);
            }
            throw new ArgumentException("Without pair count should never be more than five");
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            ISet<int> inside = new HashSet<int>(), 
                      outside = new HashSet<int>();

            var withoutPair = cards.RemovePairs();
            var handList = new List<int> { cards.Cards[0].ToInt(), cards.Cards[1].ToInt(), cards.Cards[2].ToInt(), cards.Cards[3].ToInt(), cards.Cards[4].ToInt(), cards.Cards[5].ToInt() };

            if (withoutPair.Count <= 3)
            {
                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 4)
            {
                if (withoutPair[3].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                    withoutPair = new List<Card> { withoutPair[3], withoutPair[0], withoutPair[1], withoutPair[2] };

                outside = PokerHelper.CountOutsideStraightDraws(handList, withoutPair);
                if (outside.Count > 0)
                    return PokerHelper.CreateTurnOuts(outside.Count * 4, false);

                inside = PokerHelper.CountInsideStraightDraws(handList, withoutPair);
                if (inside.Count > 0)
                    return PokerHelper.CreateTurnOuts(inside.Count * 4, false);

                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 5)
            {
                if (withoutPair[4].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[4], withoutPair[0], withoutPair[1], withoutPair[2] };
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    if (outside.Count > 0)
                        return PokerHelper.CreateTurnOuts(outside.Count * 4, false);

                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                    if (inside.Count > 0)
                        return PokerHelper.CreateTurnOuts(inside.Count * 4, false);
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromFive(withoutPair))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count*4);
                return PokerHelper.CreateRiverOuts(0);
            }
            if (withoutPair.Count == 6)
            {
                if (withoutPair[5].Rank == Rank.Ace && withoutPair[2].Rank <= Rank.Five)
                {
                    var comb = new List<Card> { withoutPair[5], withoutPair[0], withoutPair[1], withoutPair[2] };
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                foreach (var comb in PokerEnumerator.GetFourCardsFromSix(withoutPair))
                {
                    outside.UnionWith(PokerHelper.CountOutsideStraightDraws(handList, comb));
                    inside.UnionWith(PokerHelper.CountInsideStraightDraws(handList, comb));
                }

                outside.UnionWith(inside);
                if (outside.Count > 0)
                    return PokerHelper.CreateRiverOuts(outside.Count * 4);
                return PokerHelper.CreateRiverOuts(0);
            }
            throw new ArgumentException("Without pair count should never be more than six");
        }
    }
}