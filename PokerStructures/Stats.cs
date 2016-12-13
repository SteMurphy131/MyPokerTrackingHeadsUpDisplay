using System;

namespace PokerStructures
{
    public class Stats
    {
        private int _simCount;

        private int[] counts = new int[Enum.GetValues(typeof(Pokerscore)).Length];

        public void Report()
        {
            Console.WriteLine("{0,10}\t{1,10}\t{2,10}",
                "Hand", "Count", "Percent");
            for (int i = 0; i < counts.Length; ++i)
            {
                Console.WriteLine("{0,-10}\t{1,10}\t{2,10:p4}",
                    Enum.GetName(typeof(Pokerscore), i),
                    counts[i],
                    counts[i] / (double)_simCount);
            }
            Console.WriteLine("{0,10}\t{1,10}", "Total Hands", _simCount);
        }

        public void Append(Pokerscore ps)
        {
            counts[(int)ps]++;
        }

        public void reset()
        {
            for (int i = 0; i < counts.Length; ++i)
                counts[i] = 0;
        }

        public Stats()
        {
            reset();
        }
        public int simCount
        {
            set { _simCount = value; }
            get { return _simCount; }
        }
    }
}