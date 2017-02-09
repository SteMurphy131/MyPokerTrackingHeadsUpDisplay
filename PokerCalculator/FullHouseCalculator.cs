using System.Collections.Generic;
using PokerStructures;
using PokerStructures.Enums;

namespace PokerCalculator
{
    public static class FullHouseCalculator
    {
        public static int CalculateTurn(FiveCardHand cards)
        {
            return 0;
        }

        public static int CalculateRiver(SixCardHand cards)
        {
            return 4;
        }

        public static Dictionary<Pokerscore, int> RiverOutsDictionary = new Dictionary<Pokerscore, int>
        {
            {Pokerscore.TwoPair, 4},
            {Pokerscore.ThreeOfAKind, 9}
        };
    }
}