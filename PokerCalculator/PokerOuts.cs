namespace PokerCalculator
{
    public class PokerOuts
    {
        public int RoyalFlush { get; set; }
        public int StraightFlush { get; set; }
        public int FourOfAKind { get; set; }
        public int FullHouse { get; set; }
        public int Flush { get; set; }
        public int ThreeOfAKind { get; set; }
        public int Straight { get; set; }
        public int TwoPair { get; set; }
        public int Pair { get; set; }

        public PokerOuts(){}

        public void Clear()
        {
            RoyalFlush = 0;
            StraightFlush = 0;
            FourOfAKind = 0;
            FullHouse = 0;
            Flush = 0;
            ThreeOfAKind = 0;
            Straight = 0;
            TwoPair = 0;
            Pair = 0;
        }
    }
}