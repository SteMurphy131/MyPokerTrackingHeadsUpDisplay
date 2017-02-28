using PokerStructures.Enums;

namespace PokerStructures
{
    public class PokerLogic
    {
        private static bool IsFlush(FiveCardHand h)
        {
            if (h.Cards[0].Suit == h.Cards[1].Suit &&
                h.Cards[1].Suit == h.Cards[2].Suit &&
                h.Cards[2].Suit == h.Cards[3].Suit &&
                h.Cards[3].Suit == h.Cards[4].Suit)
                return true;
            return false;
        }

        // make sure the rank differs by one
        // we can do this since the Cards is 
        // sorted by this point
        private static bool IsStraight(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank - 1 &&
                h.Cards[1].Rank == h.Cards[2].Rank - 1 &&
                h.Cards[2].Rank == h.Cards[3].Rank - 1 &&
                h.Cards[3].Rank == h.Cards[4].Rank - 1)
                return true;
            // special case cause ace ranks lower
            // than 10 or higher
            if (h.Cards[4].Rank == Rank.Ace &&
                h.Cards[0].Rank == Rank.Two &&
                h.Cards[1].Rank == Rank.Three &&
                h.Cards[2].Rank == Rank.Four &&
                h.Cards[3].Rank == Rank.Five)
                return true;
            return false;
        }

        // must be flush and straight and
        // be certain cards. No wonder I have
        private static bool IsRoyalFlush(FiveCardHand h)
        {
            if (IsStraight(h) && IsFlush(h) &&
                h.Cards[0].Rank == Rank.Ten &&
                h.Cards[1].Rank == Rank.Jack &&
                h.Cards[2].Rank == Rank.Queen &&
                h.Cards[3].Rank == Rank.King &&
                h.Cards[4].Rank == Rank.Ace)
                return true;
            return false;
        }

        private static bool IsStraightFlush(FiveCardHand h)
        {
            if (IsStraight(h) && IsFlush(h))
                return true;
            return false;
        }

        /*
         * Two choices here, the first four cards
         * must match in rank, or the second four
         * must match in rank. Only because the hand
         * is sorted
         */
        private static bool IsFourOfAKind(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[1].Rank == h.Cards[2].Rank &&
                h.Cards[2].Rank == h.Cards[3].Rank)
                return true;
            if (h.Cards[1].Rank == h.Cards[2].Rank &&
                h.Cards[2].Rank == h.Cards[3].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            return false;
        }

        /*
         * two choices here, the pair is in the
         * front of the hand or in the back of the
         * hand, because it is sorted
         */
        private static bool IsFullHouse(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[2].Rank == h.Cards[3].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[1].Rank == h.Cards[2].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            return false;
        }

        /*
         * three choices here, first three cards match
         * middle three cards match or last three cards
         * match
         */
        private static bool IsThreeOfAKind(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[1].Rank == h.Cards[2].Rank)
                return true;
            if (h.Cards[1].Rank == h.Cards[2].Rank &&
                h.Cards[2].Rank == h.Cards[3].Rank)
                return true;
            if (h.Cards[2].Rank == h.Cards[3].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            return false;
        }

        /*
         * three choices, two pair in the front,
         * separated by a single card or
         * two pair in the back
         */
        private static bool IsTwoPair(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[2].Rank == h.Cards[3].Rank)
                return true;
            if (h.Cards[0].Rank == h.Cards[1].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            if (h.Cards[1].Rank == h.Cards[2].Rank &&
                h.Cards[3].Rank == h.Cards[4].Rank)
                return true;
            return false;
        }

        private static bool IsPair(FiveCardHand h)
        {
            if (h.Cards[0].Rank == h.Cards[1].Rank)
                return true;
            if (h.Cards[1].Rank == h.Cards[2].Rank)
                return true;
            if (h.Cards[2].Rank == h.Cards[3].Rank)
                return true;
            if (h.Cards[3].Rank == h.Cards[4].Rank)
                return true;

            return false;
        }

        // must be in order of hands and must be
        // mutually exclusive choices
        public static Pokerscore Score(FiveCardHand h)
        {
            h.Sort();

            if (IsRoyalFlush(h))
                return Pokerscore.RoyalFlush;
            if (IsStraightFlush(h))
                return Pokerscore.StraightFlush;
            if (IsFourOfAKind(h))
                return Pokerscore.FourOfAKind;
            if (IsFullHouse(h))
                return Pokerscore.FullHouse;
            if (IsFlush(h))
                return Pokerscore.Flush;
            if (IsStraight(h))
                return Pokerscore.Straight;
            if (IsThreeOfAKind(h))
                return Pokerscore.ThreeOfAKind;
            if (IsTwoPair(h))
                return Pokerscore.TwoPair;
            if(IsPair(h))
                return Pokerscore.Pair;
            return Pokerscore.None;
        }
    }
}