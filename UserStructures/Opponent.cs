using System;

namespace UserStructures
{
    public class Opponent
    {
        public string Name { get; set; } 
        public int HandsPlayed { get; set; }
        public int Vpip { get; set; }
        public int Pfr { get; set; }
        public int CBet { get; set; }
        public int Calls { get; set; }
        public int Checks { get; set; }
        public int Folds { get; set; }
        public int Bets { get; set; }
        public int Raises { get; set; }

        public double VpipPercentage { get; set; }
        public double PfrPercentage { get; set; }
        public double CBetPercentage { get; set; }
        public double AggFactor { get; set; }
        public double AggFrequency { get; set; }
        public double AggPercentage { get; set; }

        public bool InPlay { get; set; }
        public bool HandVpip { get; set; }
        public bool HandPfr { get; set; }
        public bool HandCBet { get; set; }

        public void Calculate()
        {
            VpipPercentage = Math.Round(Vpip / (double)HandsPlayed * 100, 2);
            PfrPercentage = Math.Round(Pfr / (double) HandsPlayed * 100, 2);
            AggFactor = Calls == 0 ? 0 : Math.Round((Bets + Raises) / (double)Calls, 2);
            AggPercentage = Calls + Checks == 0 ? 0 : Math.Round((Bets + Raises) / (double)(Bets + Raises + Calls + Checks) * 100, 2);
            AggFrequency = Calls + Folds == 0 ? 0 : Math.Round((Bets + Raises) / (double)(Bets + Raises + Calls + Folds) * 100, 2);
            CBetPercentage = Pfr == 0 ? 0 : Math.Round(CBet / (double) Pfr * 100, 2);
        }
    }
}