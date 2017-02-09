using System.Collections.Generic;
using PokerStructures;

namespace PokerCalculator
{
    public static class StraightCalculator
    {
        public static int CalculateTurn(FiveCardHand cards)
        {
            return 0;
        }

        public static int CalculateRiver(SixCardHand cards)
        {
            if (cards.HasOutsideStraightDraw())
                return 6;
            return 0;
        }
    }
}