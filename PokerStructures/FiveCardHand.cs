using System.Collections.Generic;
using System.Linq;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class FiveCardHand : Hand
    {
        public FiveCardHand(){}

        public FiveCardHand(IEnumerable<Card> cards)
        {
            Cards = cards.ToList();
        }
        
        public List<Card> RemovePairs()
        {
            CountFlush();
            var newHand = new FiveCardHand { Cards = new List<Card> { Cards[0], Cards[1], Cards[2], Cards[3], Cards[4]} };

            for (int i = Cards.Count - 2; i >= 0; i--)
            {
                if (Cards[i].Rank == Cards[i + 1].Rank)
                {
                    if(Cards[i].Suit == GetMaxSuit())
                        newHand.Cards.RemoveAt(i + 1);
                    else
                        newHand.Cards.RemoveAt(i);
                }
            }

            return newHand.Cards;
        }

        public bool HasPair()
        {
            if (Cards[0].Rank == Cards[1].Rank)
                return true;
            if (Cards[1].Rank == Cards[2].Rank)
                return true;
            if (Cards[2].Rank == Cards[3].Rank)
                return true;
            if (Cards[3].Rank == Cards[4].Rank)
                return true;

            return false;
        }

        public bool HasTwoPair()
        {
            if (Cards[0].Rank == Cards[1].Rank && Cards[2].Rank == Cards[3].Rank)
                return true;
            if (Cards[0].Rank == Cards[1].Rank && Cards[3].Rank == Cards[4].Rank)
                return true;
            if (Cards[1].Rank == Cards[2].Rank && Cards[3].Rank == Cards[4].Rank)
                return true;
            return false;
        }

        public bool HasThreeOfAKind()
        {
            if (Cards[0].Rank == Cards[1].Rank && Cards[1].Rank == Cards[2].Rank)
                return true;
            if (Cards[1].Rank == Cards[2].Rank && Cards[2].Rank == Cards[3].Rank)
                return true;
            if (Cards[2].Rank == Cards[3].Rank && Cards[3].Rank == Cards[4].Rank)
                return true;
            return false;
        }
    }
}