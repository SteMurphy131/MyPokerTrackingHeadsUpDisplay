namespace UserStructures
{
    public class SessionStatistics
    {
        public int PreFlopRaises { get; set; }
        public int PreFlopRaisePercentage { get; set; }
        public int PreFlopRaiseWinPercentage { get; set; }
        public int ContinuationBets { get; set; }
        public int HandsPlayed { get; set; }
        public int HandsPlayedToRiver { get; set; }
        public int HandsWonAtRiver { get; set; }
        public int HandsWon { get; set; }
        public int HandsFoldedBeforeRiver { get; set; }
        public int HandsWonBeforeRiver { get; set; }
    }
}