namespace PokerStructures.Calculation
{
    public static class RoyalFlushCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            int outside = cards.CountOutsideRoyalFlushDraws();
            if (outside > 0)
                return PokerHelper.CreateTurnOuts(outside, false);

            int inside = cards.CountInsideRoyalFlushDraws();
            if (inside > 0)
                return PokerHelper.CreateTurnOuts(inside, false);

            return cards.RunnerRunnerRoyalFlushDraws();
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            int outside = cards.CountOutsideRoyalFlushDraws();

            if (outside > 0)
                return PokerHelper.CreateRiverOuts(outside);

            int inside = cards.CountInsideRoyalFlushDraws();

            return PokerHelper.CreateRiverOuts(inside > 0 
                ? inside 
                : 0);
        }
    }
}