using System.Collections.Generic;
using PokerStructures;
using PokerStructures.Enums;

namespace PokerCalculator
{
    public static class PokerOutsCalculator
    {
        public static PokerOuts PokerOuts = new PokerOuts();

        public static void CalculatePreFlopOdds(List<Card> cards)
        {
            cards.Sort();
        }

        public static PokerOuts CalculateTurnOuts(FiveCardHand cards, Pokerscore currentScore)
        {
            cards.Sort();
            PokerOuts.Clear();

            switch (currentScore)
            {
                case Pokerscore.RoyalFlush:
                    return PokerOuts;
                case Pokerscore.StraightFlush:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.FourOfAKind:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.FullHouse:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.Flush:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.ThreeOfAKind:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.Straight:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateTurn(cards);
                    PokerOuts.ThreeOfAKind = ThreeOfAKindCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.TwoPair:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateTurn(cards);
                    PokerOuts.ThreeOfAKind = ThreeOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.Straight = StraightCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.Pair:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateTurn(cards);
                    PokerOuts.ThreeOfAKind = ThreeOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.Straight = StraightCalculator.CalculateTurn(cards);
                    PokerOuts.TwoPair = TwoPairCalculator.CalculateTurn(cards);
                    return PokerOuts;
                case Pokerscore.None:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateTurn(cards);
                    PokerOuts.ThreeOfAKind = ThreeOfAKindCalculator.CalculateTurn(cards);
                    PokerOuts.Straight = StraightCalculator.CalculateTurn(cards);
                    PokerOuts.TwoPair = TwoPairCalculator.CalculateTurn(cards);
                    PokerOuts.Pair = PairCalculator.CalculateTurn(cards);
                    return PokerOuts;
                default:
                    return null;
            }
        }

        public static PokerOuts CalculateRiverOuts(SixCardHand cards, Pokerscore currentScore)
        {
            cards.Sort();
            PokerOuts.Clear();

            switch (currentScore)
            {
                case Pokerscore.RoyalFlush:
                    return PokerOuts;
                case Pokerscore.StraightFlush:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    return PokerOuts;
                case Pokerscore.FourOfAKind:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    return PokerOuts;
                case Pokerscore.FullHouse:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.RiverOutsDictionary[currentScore];//done
                    return PokerOuts;
                case Pokerscore.Flush:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateRiver(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateRiver(cards);
                    return PokerOuts;
                case Pokerscore.Straight:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.CalculateRiver(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.CalculateRiver(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateRiver(cards);//done
                    return PokerOuts;
                case Pokerscore.ThreeOfAKind:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.FourOfAKind = FourOfAKindCalculator.RiverOutsDictionary[currentScore];//done
                    PokerOuts.FullHouse = FullHouseCalculator.RiverOutsDictionary[currentScore];//done
                    PokerOuts.Flush = FlushCalculator.CalculateRiver(cards);//done
                    PokerOuts.Straight = StraightCalculator.CalculateRiver(cards);
                    return PokerOuts;
                case Pokerscore.TwoPair:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.FullHouse = FullHouseCalculator.RiverOutsDictionary[currentScore];//done
                    PokerOuts.Flush = FlushCalculator.CalculateRiver(cards);//done
                    PokerOuts.Straight = StraightCalculator.CalculateRiver(cards);
                    return PokerOuts;
                case Pokerscore.Pair:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateRiver(cards);//done
                    PokerOuts.ThreeOfAKind = ThreeOfAKindCalculator.CalculateRiver(cards);//done
                    PokerOuts.Straight = StraightCalculator.CalculateRiver(cards);
                    PokerOuts.TwoPair = TwoPairCalculator.CalculateRiver(cards);//done
                    return PokerOuts;
                case Pokerscore.None:
                    PokerOuts.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    PokerOuts.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    PokerOuts.Flush = FlushCalculator.CalculateRiver(cards);//done
                    PokerOuts.Straight = StraightCalculator.CalculateRiver(cards);
                    PokerOuts.Pair = PairCalculator.CalculateRiver(cards);//done
                    return PokerOuts;
                default:
                    return null;
            }
        }

        public static void CalculateFinalWinChance(List<Card> cards)
        {

        }
    }
}