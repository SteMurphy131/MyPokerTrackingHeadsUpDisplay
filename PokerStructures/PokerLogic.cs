using PokerStructures.Enums;

namespace PokerStructures
{
    public class PokerLogic
    {
        private static bool IsFlush(FiveCardHand h)
        {
            if (h.Hand[0].Suit == h.Hand[1].Suit &&
                h.Hand[1].Suit == h.Hand[2].Suit &&
                h.Hand[2].Suit == h.Hand[3].Suit &&
                h.Hand[3].Suit == h.Hand[4].Suit)
                return true;
            return false;
        }

        // make sure the rank differs by one
        // we can do this since the Hand is 
        // sorted by this point
        private static bool IsStraight(FiveCardHand h)
        {
            if (h.Hand[0].Rank == h.Hand[1].Rank - 1 &&
                h.Hand[1].Rank == h.Hand[2].Rank - 1 &&
                h.Hand[2].Rank == h.Hand[3].Rank - 1 &&
                h.Hand[3].Rank == h.Hand[4].Rank - 1)
                return true;
            // special case cause ace ranks lower
            // than 10 or higher
            if (h.Hand[4].Rank == Rank.Ace &&
                h.Hand[0].Rank == Rank.Two &&
                h.Hand[1].Rank == Rank.Three &&
                h.Hand[2].Rank == Rank.Four &&
                h.Hand[3].Rank == Rank.Five)
                return true;
            return false;
        }

        // must be flush and straight and
        // be certain cards. No wonder I have
        private static bool IsRoyalFlush(FiveCardHand h)
        {
            if (IsStraight(h) && IsFlush(h) &&
                h.Hand[0].Rank == Rank.Ten &&
                h.Hand[1].Rank == Rank.Jack &&
                h.Hand[2].Rank == Rank.Queen &&
                h.Hand[3].Rank == Rank.King &&
                h.Hand[4].Rank == Rank.Ace)
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
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[1].Rank == h.Hand[2].Rank &&
                h.Hand[2].Rank == h.Hand[3].Rank)
                return true;
            if (h.Hand[1].Rank == h.Hand[2].Rank &&
                h.Hand[2].Rank == h.Hand[3].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
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
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[2].Rank == h.Hand[3].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
                return true;
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[1].Rank == h.Hand[2].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
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
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[1].Rank == h.Hand[2].Rank)
                return true;
            if (h.Hand[1].Rank == h.Hand[2].Rank &&
                h.Hand[2].Rank == h.Hand[3].Rank)
                return true;
            if (h.Hand[2].Rank == h.Hand[3].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
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
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[2].Rank == h.Hand[3].Rank)
                return true;
            if (h.Hand[0].Rank == h.Hand[1].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
                return true;
            if (h.Hand[1].Rank == h.Hand[2].Rank &&
                h.Hand[3].Rank == h.Hand[4].Rank)
                return true;
            return false;
        }

        private static bool IsPair(FiveCardHand h)
        {
            if (h.Hand[0].Rank == h.Hand[1].Rank)
                return true;
            if (h.Hand[1].Rank == h.Hand[2].Rank)
                return true;
            if (h.Hand[2].Rank == h.Hand[3].Rank)
                return true;
            if (h.Hand[3].Rank == h.Hand[4].Rank)
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