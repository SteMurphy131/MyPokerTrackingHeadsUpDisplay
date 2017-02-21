using System.Collections.Generic;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace PokerStructures
{
    public static class PokerHelper
    {
        public static readonly Dictionary<string, Suit> SuitDictionary = new Dictionary<string, Suit>
        {
            {"d", Suit.Diamonds},
            {"h", Suit.Hearts},
            {"c", Suit.Clubs},
            {"s", Suit.Spades}
        };

        public static readonly Dictionary<int, Rank> RankDictionary = new Dictionary<int, Rank>
        {
            {2,  Rank.Two},
            {3,  Rank.Three},
            {4,  Rank.Four},
            {5,  Rank.Five},
            {6,  Rank.Six},
            {7,  Rank.Seven},
            {8,  Rank.Eight},
            {9,  Rank.Nine},
            {10, Rank.Ten},
            {11, Rank.Jack},
            {12, Rank.Queen},
            {13, Rank.King},
            {14, Rank.Ace}
        };

        public static PokerScoreOuts CreateRiverOuts(int outs)
        {
            double percentage = ((double)outs/46)*100;
            return new PokerScoreOuts {Outs = outs, Percentage = percentage, RunnerRunner = false};
        }

        public static PokerScoreOuts CreateTurnOuts(int outs, bool runner)
        {
            double percentage = (double)outs/47 * 100;
            return new PokerScoreOuts { Outs = outs, Percentage = percentage, RunnerRunner = runner};
        }
    }
}