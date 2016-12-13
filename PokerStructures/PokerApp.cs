using System;

namespace PokerStructures
{
    public class PokerApp
    {
        public static void Main(string[] args)
        {
            int simCount = 5000;
            if (args.Length == 1)
                simCount = int.Parse(args[0]);

            Deck d = new Deck();
            PokerHand hand = new PokerHand(d);

            Stats stats = new Stats();
            stats.simCount = simCount;
            for (int i = 0; i < simCount; i++)
            {
                // worry counter
                if ((i % 1000) == 0)
                    Console.Write("*");
                d.shuffle();
                hand.pullCards();
                hand.Sort();
                Pokerscore ps = PokerLogic.score(hand);
                stats.Append(ps);
            }
            Console.WriteLine();
            stats.Report();
        }
    }
}