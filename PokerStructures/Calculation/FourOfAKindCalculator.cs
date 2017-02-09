using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public static class FourOfAKindCalculator
    {
        public static PokerScoreOuts CalculateTurn(FiveCardHand cards)
        {
            return PokerHelper.CreateTurnOuts(0, false);
        }

        public static PokerScoreOuts CalculateRiver(SixCardHand cards)
        {
            return cards.HasThreeOfAKind() 
                ? PokerHelper.CreateRiverOuts(1) 
                : PokerHelper.CreateRiverOuts(0);
        }

        public static Dictionary<Pokerscore, PokerScoreOuts> RiverOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.ThreeOfAKind, PokerHelper.CreateRiverOuts(1)},
            {Pokerscore.FullHouse, PokerHelper.CreateRiverOuts(1)},
        };

        public static Dictionary<Pokerscore, PokerScoreOuts> TurnOutsDictionary = new Dictionary<Pokerscore, PokerScoreOuts>
        {
            {Pokerscore.ThreeOfAKind, PokerHelper.CreateTurnOuts(1, false)}
        };
    }
}                   