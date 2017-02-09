namespace PokerStructures.Calculation
{
    public static class StraightFlushCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return new PokerScoreOuts { Outs = 0, Percentage = 0, RunnerRunner = true };
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            int outside = cards.CountOutsideStraightFlushDraws();

            if (outside > 0)
                return new PokerScoreOuts { Outs = outside, Percentage = (outside/46)*100, RunnerRunner = true }; ;

            int inside = cards.CountInsideStraightFlushDraws();

            return inside > 0 ?
                new PokerScoreOuts { Outs = inside, Percentage = (inside/46)*100, RunnerRunner = true } :
                new PokerScoreOuts { Outs = 0, Percentage = 0, RunnerRunner = true }; 
        }
    }
}