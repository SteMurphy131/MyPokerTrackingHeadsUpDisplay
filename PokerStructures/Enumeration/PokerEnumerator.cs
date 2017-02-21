using System.Collections.Generic;
using System.Linq;

namespace PokerStructures.Enumeration
{
    public static class PokerEnumerator
    {
        public static IEnumerable<IEnumerable<Card>> GetCombinationsOfNMinusOne(IEnumerable<Card> cards, int count)
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                yield return cards.Where((c, index) => index != i);
            }
        }

        public static IEnumerable<IEnumerable<Card>> GetCombinationsOfNMinusTwo(IEnumerable<Card> cards, int count)
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                for (int j = i+1; j < cards.Count(); j++)
                {
                    yield return cards.Where((c, index) => index != i && index != j);
                }
            }
        }

        public static IEnumerable<List<Card>> GetFourCardsFromSix(List<Card> cards)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return cards.GetRange(i, 4);
            }
        }

        public static IEnumerable<List<Card>> GetFourCardsFromFive(List<Card> cards)
        {
            for (int i = 0; i < 2; i++)
            {
                yield return cards.GetRange(i, 4);
            }
        }

        public static IEnumerable<List<Card>> GetThreeCardsFromFive(List<Card> cards)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return cards.GetRange(i, 3);
            }
        }
    }
}