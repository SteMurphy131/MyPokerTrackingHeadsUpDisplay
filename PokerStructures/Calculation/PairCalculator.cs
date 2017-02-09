using System.Collections.Generic;

namespace PokerStructures.Calculation
{
    public static class PairCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return PokerHelper.CreateTurnOuts(15, false);
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return PokerHelper.CreateRiverOuts(18);
        }
    }
}