using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public static class FullHouseCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return PokerHelper.CreateTurnOuts(0, false);
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            if (cards.HasThreePair())
                return PokerHelper.CreateRiverOuts(6);
            if (cards.HasThreeOfAKind())
                return PokerHelper.CreateRiverOuts(9);
            if (cards.HasTwoPair())
                return PokerHelper.CreateRiverOuts(4);
            
            return PokerHelper.CreateRiverOuts(0);
        }

        public static Dictionary<Pokerscore, PokerScoreOuts> RiverOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.TwoPair, PokerHelper.CreateRiverOuts(4)},
            {Pokerscore.ThreeOfAKind, PokerHelper.CreateRiverOuts(9)}
        };

        public static Dictionary<Pokerscore, PokerScoreOuts> TurnOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.TwoPair, PokerHelper.CreateTurnOuts(4, false)},
            {Pokerscore.ThreeOfAKind, PokerHelper.CreateTurnOuts(6, false)}
        };
    }
}