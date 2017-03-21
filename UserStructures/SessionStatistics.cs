using PokerStructures.Enums;

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

        public int VoluntaryPutInPot { get; set; }
        public int VpipWin { get; set; }

        public int TotalCalls { get; set; }
        public int TotalBets { get; set; }
        public int TotalRaises { get; set; }
        public int TotalChecks { get; set; }
        public int TotalFolds { get; set; }

        public double PreFlopRaisePercentage { get; set; }
        public double PreFlopRaiseWinPercentage { get; set; }
        public double ContinuationBetsPercentage { get; set; }
        public double ContinuationBetWinPercentage { get; set; }
        public double VpipPercentage { get; set; }
        public double VpipWinPercentage { get; set; }
        public double AggressionFactor { get; set; }
        public double AggressionPercentage { get; set; }
        public double AggressionFrequency { get; set; }
        public double FlopsSeen { get; set; }
        public double FlopsSeenPercentage { get; set; }
        public double HandsWonPercentage { get; set; }

        public PlayingStyle VpipStyle { get; set; }
        public PlayingStyle PfrStyle { get; set; }
        public PlayingStyle AggStyle { get; set; }

        public int AggressionTotal { get; set; }

        public void Calculate()
        {
            FlopsSeen = HandsPlayed - HandsFoldedBeforeFlop;
            FlopsSeenPercentage = FlopsSeen / (double) HandsPlayed * 100;
            PreFlopRaisePercentage = PreFlopRaises/(double) HandsPlayed*100;
            PreFlopRaiseWinPercentage = PreFlopRaiseWin/(double) PreFlopRaises*100;
            ContinuationBetsPercentage = ContinuationBets / (double) PreFlopRaises * 100;
            ContinuationBetWinPercentage = ContinuationBetsWin/(double) ContinuationBets*100;
            VpipPercentage = VoluntaryPutInPot / (double) HandsPlayed * 100;
            VpipWinPercentage = VpipWin / (double) VoluntaryPutInPot * 100;
            AggressionFactor = (TotalBets + TotalRaises) / (double) TotalCalls;
            AggressionPercentage = (TotalBets + TotalRaises) / (double) (TotalBets + TotalRaises + TotalCalls + TotalChecks) *100;
            AggressionFrequency = (TotalBets + TotalRaises) / (double) (TotalBets + TotalRaises + TotalCalls + TotalFolds) * 100;
            HandsWonPercentage = HandsWon / FlopsSeen * 100;

            CalculateStyle();
        }

        private void CalculateStyle()
        {
            if(VpipPercentage <= 7)
                VpipStyle = PlayingStyle.Aggressive;
            else if(VpipPercentage >= 8 && VpipPercentage <= 18)
                VpipStyle = PlayingStyle.Mid;
            else 
                VpipStyle = PlayingStyle.Passive;

            var vpipPfrGap = VpipPercentage - PreFlopRaisePercentage;

            if(vpipPfrGap <= 3)
                PfrStyle = PlayingStyle.Aggressive;
            else if (vpipPfrGap <= 6 && vpipPfrGap >= 4)
                PfrStyle = PlayingStyle.Mid;
            else
                PfrStyle = PlayingStyle.Passive;

            if(AggressionFrequency <= 30)
                AggStyle = PlayingStyle.Passive;
            else if (AggressionFrequency <= 60 && AggressionFrequency >= 31)
                AggStyle = PlayingStyle.Mid;
            else
                AggStyle = PlayingStyle.Aggressive;

            AggressionTotal = (int) VpipStyle + (int) PfrStyle + (int) AggStyle;
        }
    }
}