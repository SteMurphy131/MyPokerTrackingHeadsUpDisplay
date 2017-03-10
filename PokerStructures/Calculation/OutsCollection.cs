using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public class OutsCollection
    {
        public PokerScoreOuts RoyalFlush { get; set; }
        public PokerScoreOuts StraightFlush { get; set; }
        public PokerScoreOuts FourOfAKind { get; set; }
        public PokerScoreOuts FullHouse { get; set; }
        public PokerScoreOuts Flush { get; set; }
        public PokerScoreOuts ThreeOfAKind { get; set; }
        public PokerScoreOuts Straight { get; set; }
        public PokerScoreOuts TwoPair { get; set; }
        public PokerScoreOuts Pair { get; set; }

        public OutsCollection()
        {
            RoyalFlush = new PokerScoreOuts();
            StraightFlush = new PokerScoreOuts();
            FourOfAKind = new PokerScoreOuts();
            FullHouse = new PokerScoreOuts();
            Flush = new PokerScoreOuts();
            ThreeOfAKind = new PokerScoreOuts();
            Straight = new PokerScoreOuts();
            TwoPair = new PokerScoreOuts();
            Pair = new PokerScoreOuts();
        }

        public void Clear()
        {
            RoyalFlush = null;
            StraightFlush = null;
            FourOfAKind = null;
            FullHouse = null;
            Flush = null;
            ThreeOfAKind = null;
            Straight = null;
            TwoPair = null;
            Pair = null;
        }

        public Pokerscore BestScore()
        {
            if (RoyalFlush.Percentage > 0)
                return Pokerscore.RoyalFlush;
            if (StraightFlush.Percentage > 0)
                return Pokerscore.StraightFlush;
            if (FourOfAKind.Percentage > 0)
                return Pokerscore.FourOfAKind;
            if (FullHouse.Percentage > 0)
                return Pokerscore.FullHouse;
            if (Flush.Percentage > 0)
                return Pokerscore.Flush;
            if (Straight.Percentage > 0)
                return Pokerscore.Straight;
            if (ThreeOfAKind.Percentage > 0)
                return Pokerscore.ThreeOfAKind;
            if (TwoPair.Percentage > 0)
                return Pokerscore.TwoPair;
            return Pokerscore.Pair;
        }

        public PokerScoreOuts BestPossible()
        {
            if (RoyalFlush.Percentage > 0)
                return RoyalFlush;
            if (StraightFlush.Percentage > 0)
                return StraightFlush;
            if (FourOfAKind.Percentage > 0)
                return FourOfAKind;
            if (FullHouse.Percentage > 0)
                return FullHouse;
            if (Flush.Percentage > 0)
                return Flush;
            if (Straight.Percentage > 0)
                return Straight;
            if (ThreeOfAKind.Percentage > 0)
                return ThreeOfAKind;
            if (TwoPair.Percentage > 0)
                return TwoPair;
            return Pair;
        }
    }
}