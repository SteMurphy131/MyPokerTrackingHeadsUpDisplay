namespace PokerStructures.Calculation
{
    public static class RoyalFlushCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return PokerHelper.CreateTurnOuts(0, false);
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return PokerHelper.CreateRiverOuts(0);
        }
    }
}