using System.Collections.Generic;
using System.Linq;
using PokerStructures;
using PokerStructures.Enums;

namespace PokerStructures.ExtensionMethods
{
    public static class Extensions
    {
        public static bool HasPair(this List<Card> cards)
        {
            for (int i = 0; i < cards.Count()-1; i++)
            {
                if (cards[i].Rank == cards[i + 1].Rank)
                    return true;
            }
            return false;
        }

        public static bool AreSameSuit(this List<Card> cards)
        {
            for (int i = 0; i < cards.Count() - 1; i++)
            {
                if (cards[i].Suit != cards[i + 1].Suit)
                    return false;
            }
            return true;
        }

        public static int MaxSuit(this List<Card> cards)
        {
            int[] counters = new int[4];

            for (int i = 0; i < cards.Count(); i++)
            {
                switch (cards[i].Suit)
                {
                    case Suit.Clubs:
                        counters[0]++;
                        break;
                    case Suit.Hearts:
                        counters[1]++;
                        break;
                    case Suit.Spades:
                        counters[2]++;
                        break;
                    case Suit.Diamonds:
                        counters[3]++;
                        break;
                }
            }

            return counters.Max();
        }

        public static bool AreTenOrAbove(this List<Card> cards)
        {
            for (int i = 0; i < cards.Count() - 1; i++)
            {
                if (cards[i].Rank < Rank.Ten)
                    return false;
            }
            return true;
        }
    }
}