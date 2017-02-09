using System.Collections.Generic;
using PokerStructures;
using PokerStructures.Enums;

namespace PokerCalculator
{
    public static class FourOfAKindCalculator
    {
        public static int CalculateTurn(FiveCardHand cards)
        {
            return 0;
        }

        public static int CalculateRiver(SixCardHand cards)
        {
            //Check if there are 3 cards with the same rank, if there are return 1 else return 0
            return 0;
        }

        public static Dictionary<Pokerscore, int> RiverOutsDictionary = new Dictionary<Pokerscore, int>
        {
            {Pokerscore.ThreeOfAKind, 1},
            {Pokerscore.FullHouse, 1},
        };
    }
}