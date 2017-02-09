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
    }
}