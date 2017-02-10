using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public static class TwoPairCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return new PokerScoreOuts {Outs = 0, Percentage = 0, RunnerRunner = true};
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return new PokerScoreOuts {Outs = 12, Percentage = 26.1, RunnerRunner = false};
        }

        public static Dictionary<Pokerscore, PokerScoreOuts> TurnOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.None, new PokerScoreOuts {Outs = 0, Percentage = 8.326, RunnerRunner = true} },
            {Pokerscore.Pair, new PokerScoreOuts {Outs = 9, Percentage = 35.0, RunnerRunner = false} }
        };
    }
}