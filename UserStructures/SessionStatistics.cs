﻿using System;
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
        
        public PlayingStyle PfrStyle { get; set; }
        public PlayingStyle CBetStyle { get; set; }
        public PlayingStyle AggFreqStyle { get; set; }
        public PlayingStyle AggFactStyle { get; set; }
        public PlayingStyle AggPercStyle { get; set; }

        public int AggressionTotal { get; set; }

        public void Calculate()
        {
            FlopsSeen = HandsPlayed - HandsFoldedBeforeFlop;

            if (HandsPlayed == 0)
                FlopsSeenPercentage = 0;
            else
                FlopsSeenPercentage = FlopsSeen / (double) HandsPlayed * 100;

            if (HandsPlayed == 0)
                PreFlopRaisePercentage = 0;
            else
                PreFlopRaisePercentage = PreFlopRaises/(double) HandsPlayed*100;

            if (PreFlopRaises == 0)
                PreFlopRaiseWinPercentage = 0;
            else
                PreFlopRaiseWinPercentage = PreFlopRaiseWin/(double) PreFlopRaises*100;

            if (PreFlopRaises == 0)
                ContinuationBetsPercentage = 0;
            else
                ContinuationBetsPercentage = ContinuationBets / (double) PreFlopRaises * 100;

            if (ContinuationBets == 0)
                ContinuationBetWinPercentage = 0;
            else
                ContinuationBetWinPercentage = ContinuationBetsWin/(double) ContinuationBets*100;

            if (HandsPlayed == 0)
                VpipPercentage = 0;
            else
                VpipPercentage = VoluntaryPutInPot / (double) HandsPlayed * 100;

            if (VoluntaryPutInPot == 0)
                VpipWinPercentage = 0;
            else
                VpipWinPercentage = VpipWin / (double) VoluntaryPutInPot * 100;
            
            if (TotalCalls == 0)
                AggressionFactor = TotalBets + TotalRaises;
            else
                AggressionFactor = (TotalBets + TotalRaises) / (double) TotalCalls;

            if (TotalBets + TotalRaises + TotalCalls + TotalChecks == 0)
                AggressionPercentage = 0;
            else
                AggressionPercentage = (TotalBets + TotalRaises) / (double) (TotalBets + TotalRaises + TotalCalls + TotalChecks) *100;

            if (TotalBets + TotalRaises + TotalCalls + TotalFolds == 0)
                AggressionFrequency = 0;
            else
                AggressionFrequency = (TotalBets + TotalRaises) / (double) (TotalBets + TotalRaises + TotalCalls + TotalFolds) * 100;

            if (HandsPlayed == 0)
                HandsWonPercentage = 0;
            else
                HandsWonPercentage = HandsWon / (double) HandsPlayed * 100;

            FlopsSeen = Math.Round(FlopsSeen, 2);
            FlopsSeenPercentage = Math.Round(FlopsSeenPercentage, 2);
            PreFlopRaisePercentage = Math.Round(PreFlopRaisePercentage, 2);
            PreFlopRaiseWinPercentage = Math.Round(PreFlopRaiseWinPercentage, 2);
            ContinuationBetsPercentage = Math.Round(ContinuationBetsPercentage, 2);
            ContinuationBetWinPercentage = Math.Round(ContinuationBetWinPercentage, 2);
            VpipPercentage = Math.Round(VpipPercentage, 2);
            VpipWinPercentage = Math.Round(VpipWinPercentage, 2);
            AggressionFactor = Math.Round(AggressionFactor, 2);
            AggressionPercentage = Math.Round(AggressionPercentage, 2);
            AggressionFrequency = Math.Round(AggressionFrequency, 2);
            HandsWonPercentage = Math.Round(HandsWonPercentage, 2);

            CalculateStyle();
        }

        private void CalculateStyle()
        {
            var vpipPfrGap = VpipPercentage - PreFlopRaisePercentage;

            if(vpipPfrGap <= 3)
                PfrStyle = PlayingStyle.Aggressive;
            else if (vpipPfrGap <= 6)
                PfrStyle = PlayingStyle.Mid;
            else
                PfrStyle = PlayingStyle.Passive;

            if(ContinuationBetsPercentage <= 30)
                CBetStyle = PlayingStyle.Passive;
            else if(ContinuationBetsPercentage <= 60)
                CBetStyle = PlayingStyle.Mid;
            else 
                CBetStyle = PlayingStyle.Aggressive;

            if(AggressionFactor <= 1)
                AggFactStyle = PlayingStyle.Passive;
            else if(AggressionFactor <= 2)
                AggFactStyle = PlayingStyle.Mid;
            else
                AggFactStyle = PlayingStyle.Aggressive;

            if (AggressionFrequency <= 30)
                AggFreqStyle = PlayingStyle.Passive;
            else if (AggressionFrequency <= 60)
                AggFreqStyle = PlayingStyle.Mid;
            else
                AggFreqStyle = PlayingStyle.Aggressive;

            if(AggressionPercentage <= 30)
                AggPercStyle = PlayingStyle.Passive;
            else if(AggressionPercentage <= 60)
                AggPercStyle = PlayingStyle.Mid;
            else 
                AggPercStyle = PlayingStyle.Aggressive;

            AggressionTotal = (int) PfrStyle + (int) CBetStyle + (int) AggFactStyle + (int) AggFreqStyle + (int) AggPercStyle;
        }
    }
}