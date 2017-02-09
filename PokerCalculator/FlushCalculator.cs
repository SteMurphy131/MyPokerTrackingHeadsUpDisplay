using System.Collections.Generic;
using PokerStructures;

namespace PokerCalculator
{
    public static class FlushCalculator
    {
        public static int CalculateTurn(FiveCardHand cards)
        {
            if (cards.CountFlush() == 4)
                return 9;
            if (cards.CountFlush() == 3)
                return 10;
            
            return 0;
        }

        public static int CalculateRiver(SixCardHand cards)
        {
            //if there are 4 of the same suit there are 9 more of that suit we can hit
            return cards.CountFlush() == 4 ? 9 : 0;
        }
    }
}