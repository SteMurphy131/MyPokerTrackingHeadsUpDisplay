namespace PokerStructures.Calculation
{
    public class PokerScoreOuts
    {
        public double Outs { get; set; }
        public double Percentage { get; set; }
        public bool RunnerRunner { get; set; }

        public PokerScoreOuts(double outs, double percent, bool runner)
        {
            Outs = outs;
            Percentage = percent;
            RunnerRunner = runner;
        }

        public PokerScoreOuts(){}
    }
}