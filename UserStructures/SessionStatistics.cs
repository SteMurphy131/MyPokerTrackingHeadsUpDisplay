namespace UserStructures
{
    public class SessionStatistics
    {
        public int PreFlopRaises { get; set; }
        public int PreFlopRaiseWin { get; set; }
        
        public int ContinuationBets { get; set; }
        public int ContinuationBetsWin { get; set; }

        public int HandsPlayed { get; set; }
        public int HandsPlayedToRiver { get; set; }

        public int HandsWonAtRiver { get; set; }
        public int HandsWon { get; set; }
        
        public int HandsWonBeforeRiver { get; set; }
        public int HandsWonBeforeFlop { get; set; }

        public int HandsFoldedBeforeRiver { get; set; }
        public int HandsFoldedBeforeFlop { get; set; }

        public double PreFlopRaisePercentage { get; set; }
        public double PreFlopRaiseWinPercentage { get; set; }
        public double ContinuationBetWinPercentage { get; set; }

        public void Calculate()
        {
            PreFlopRaisePercentage = PreFlopRaises/(double) HandsPlayed*100;
            PreFlopRaiseWinPercentage = PreFlopRaiseWin/(double) PreFlopRaises*100;
            ContinuationBetWinPercentage = ContinuationBetsWin/(double) ContinuationBets*100;
        }
    }
}