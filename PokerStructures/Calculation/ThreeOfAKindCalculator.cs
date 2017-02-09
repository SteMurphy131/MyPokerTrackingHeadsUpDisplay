namespace PokerStructures.Calculation
{
    public static class ThreeOfAKindCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return new PokerScoreOuts { Outs = 0, Percentage = 0, RunnerRunner = true };
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return new PokerScoreOuts { Outs = 2, Percentage = 4.3, RunnerRunner = false };
        }
    }
}