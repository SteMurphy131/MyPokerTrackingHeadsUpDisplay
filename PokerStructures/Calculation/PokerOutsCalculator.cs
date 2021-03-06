﻿using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Calculation
{
    public static class PokerOutsCalculator
    {
        public static OutsCollection OutsCollection = new OutsCollection();

        public static void CalculatePreFlopOdds(List<Card> cards)
        {
            cards.Sort();
        }

        public static OutsCollection CalculateTurnOuts(FiveCardHand cards, Pokerscore currentScore)
        {
            cards.Sort();
            OutsCollection.Clear();

            switch (currentScore)
            {
                case Pokerscore.RoyalFlush:
                    return OutsCollection;
                case Pokerscore.StraightFlush:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.FourOfAKind:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.FullHouse:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.TurnOutsDictionary[currentScore];
                    return OutsCollection;
                case Pokerscore.Flush:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    OutsCollection.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.Straight:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.CalculateTurn(cards);
                    OutsCollection.FullHouse = FullHouseCalculator.CalculateTurn(cards);
                    OutsCollection.Flush = FlushCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.ThreeOfAKind:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.FullHouse = FullHouseCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Flush = FlushCalculator.CalculateTurn(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.TwoPair:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.FullHouse = FullHouseCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Flush = FlushCalculator.CalculateTurn(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateTurn(cards);
                    return OutsCollection;
                case Pokerscore.Pair:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.TurnOutsDictionary[currentScore]; 
                    OutsCollection.FullHouse = FullHouseCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Flush = FlushCalculator.CalculateTurn(cards);
                    OutsCollection.ThreeOfAKind = ThreeOfAKindCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Straight = StraightCalculator.CalculateTurn(cards);
                    OutsCollection.TwoPair = TwoPairCalculator.TurnOutsDictionary[currentScore];
                    return OutsCollection;
                case Pokerscore.None:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateTurn(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateTurn(cards);
                    OutsCollection.Flush = FlushCalculator.CalculateTurn(cards);
                    OutsCollection.ThreeOfAKind = ThreeOfAKindCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Straight = StraightCalculator.CalculateTurn(cards);
                    OutsCollection.TwoPair = TwoPairCalculator.TurnOutsDictionary[currentScore];
                    OutsCollection.Pair = PairCalculator.CalculateTurn(cards);
                    return OutsCollection;
                default:
                    return null;
            }
        }

        public static OutsCollection CalculateRiverOuts(SixCardHand cards, Pokerscore currentScore)
        {
            cards.Sort();
            OutsCollection.Clear();

            switch (currentScore)
            {
                case Pokerscore.RoyalFlush:
                    return OutsCollection;
                case Pokerscore.StraightFlush:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.FourOfAKind:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.FullHouse:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.RiverOutsDictionary[currentScore];
                    return OutsCollection;
                case Pokerscore.Flush:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.CalculateRiver(cards);
                    OutsCollection.FullHouse = FullHouseCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.Straight:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.CalculateRiver(cards);
                    OutsCollection.FullHouse = FullHouseCalculator.CalculateRiver(cards);
                    OutsCollection.Flush = FlushCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.ThreeOfAKind:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.FourOfAKind = FourOfAKindCalculator.RiverOutsDictionary[currentScore];
                    OutsCollection.FullHouse = FullHouseCalculator.RiverOutsDictionary[currentScore];
                    OutsCollection.Flush = FlushCalculator.CalculateRiver(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.TwoPair:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.FullHouse = FullHouseCalculator.RiverOutsDictionary[currentScore];
                    OutsCollection.Flush = FlushCalculator.CalculateRiver(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.Pair:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.Flush = FlushCalculator.CalculateRiver(cards);
                    OutsCollection.ThreeOfAKind = ThreeOfAKindCalculator.CalculateRiver(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateRiver(cards);
                    OutsCollection.TwoPair = TwoPairCalculator.CalculateRiver(cards);
                    return OutsCollection;
                case Pokerscore.None:
                    OutsCollection.RoyalFlush = RoyalFlushCalculator.CalculateRiver(cards);
                    OutsCollection.StraightFlush = StraightFlushCalculator.CalculateRiver(cards);
                    OutsCollection.Flush = FlushCalculator.CalculateRiver(cards);
                    OutsCollection.Straight = StraightCalculator.CalculateRiver(cards);
                    OutsCollection.Pair = PairCalculator.CalculateRiver(cards);
                    return OutsCollection;
                default:
                    return null;
            }
        }

        public static void CalculateFinalWinChance(List<Card> cards)
        {

        }
    }
}