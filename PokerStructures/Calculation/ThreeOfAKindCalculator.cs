using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public static class ThreeOfAKindCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return new PokerScoreOuts { Outs = 0, Percentage = 0, RunnerRunner = true };
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return new PokerScoreOuts { Outs = 2, Percentage = 4.3, RunnerRunner = false };
        }

        public static Dictionary<Pokerscore, PokerScoreOuts> TurnOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.None, new PokerScoreOuts {Outs = 0, Percentage = 1.387, RunnerRunner = true} },
            {Pokerscore.Pair, new PokerScoreOuts {Outs = 2, Percentage = 8.4, RunnerRunner = false} }
        };
    }
}