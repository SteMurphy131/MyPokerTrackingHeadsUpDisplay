namespace PokerStructures.Calculation
{
    public static class FlushCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            if (cards.CountFlush() == 4)
                return PokerHelper.CreateTurnOuts(9, false);
            if (cards.CountFlush() == 3)
                return new PokerScoreOuts {Outs = 0, Percentage = 4.163, RunnerRunner = true};
            
            return PokerHelper.CreateTurnOuts(0, false);
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            //if there are 4 of the same suit there are 9 more of that suit we can hit
            return cards.CountFlush() == 4 
                ? PokerHelper.CreateRiverOuts(9) 
                : PokerHelper.CreateRiverOuts(0);
        }
    }
}