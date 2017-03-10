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

        public static string ToNiceString(this Pokerscore score)
        {
            switch (score)
            {
                case Pokerscore.None:
                    return "None";
                case Pokerscore.Pair:
                    return "Pair";
                case Pokerscore.TwoPair:
                    return "Two Pair";
                case Pokerscore.ThreeOfAKind:
                    return "Trips";
                case Pokerscore.Straight:
                    return "Straight";
                case Pokerscore.Flush:
                    return "Flush";
                case Pokerscore.FullHouse:
                    return "Full House";
                case Pokerscore.FourOfAKind:
                    return "Quads";
                case Pokerscore.StraightFlush:
                    return "S Flush";
                case Pokerscore.RoyalFlush:
                    return "R Flush";
                default:
                    return "None";
            }
        }
    }
}