namespace PokerStructures.Calculation
{
    public static class StraightCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            int outside = cards.CountOutsideStraightDraws();
            if (outside > 0)
                return PokerHelper.CreateTurnOuts(outside*4, false);

            int inside = cards.CountInsideStraightDraws();
            if (inside > 0)
                return PokerHelper.CreateTurnOuts(inside*4, false);

            if(cards.HasEvenlySpacedCards())
                return new PokerScoreOuts {Outs = 0, Percentage = 2.96, RunnerRunner = true};

            return cards.RunnerRunnerStraightDraws();
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            int outside = cards.CountOutsideStraightDraws();

            if(outside > 0)
                return PokerHelper.CreateRiverOuts(outside*4);

            int inside = cards.CountInsideStraightDraws();

            if (inside > 0)
                return PokerHelper.CreateRiverOuts(inside*4);

            return PokerHelper.CreateRiverOuts(0);
        }
    }
}