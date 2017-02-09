using System.Collections.Generic;
using PokerStructures;
using PokerStructures.Enums;

namespace PokerCalculator
{
    public static class PokerEvaluator
    {
        public static Pokerscore CalculateFlopScore(List<Card> cards)
        {
            return PokerLogic.Score(new FiveCardHand(cards));
        }

        public static Pokerscore CalculateTurnScore(List<Card> cards)
        {
            Pokerscore bestScore = Pokerscore.None;

            foreach (var combination in PokerEnumerator.GetCombinationsOfNMinusOne(cards, 5))
            {
                Pokerscore score = PokerLogic.Score(new FiveCardHand(combination));

                if (score > bestScore)
                    bestScore = score;
            }

            return bestScore;
        }

        public static Pokerscore CalculateRiverScore(List<Card> cards)
        {
            Pokerscore bestScore = Pokerscore.None;

            foreach (var combination in PokerEnumerator.GetCombinationsOfNMinusTwo(cards, 5))
            {
                Pokerscore score = PokerLogic.Score(new FiveCardHand(combination));

                if (score > bestScore)
                    bestScore = score;
            }

            return bestScore;
        }
    }
}