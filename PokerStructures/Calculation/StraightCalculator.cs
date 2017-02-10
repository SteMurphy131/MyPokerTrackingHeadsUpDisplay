namespace PokerStructures.Calculation
{
    public static class StraightCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            int outside = cards.CountOutsideStraightDraws();

            if (outside > 0)
                return PokerHelper.CreateTurnOuts(outside, false);

            int inside = cards.CountInsideStraightDraws();

            if (inside > 0)
                return PokerHelper.CreateTurnOuts(inside, false);

            return PokerHelper.CreateTurnOuts(0, false);
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