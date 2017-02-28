using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class FiveCardHandRemovingPairs
    {
        [Test]
        public void RemoveTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(3, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(20, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Jack && newCards[2].Rank == Rank.Ace);
        }

        [Test]
        public void RemoveOnePair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(4, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(20, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && newCards[2].Rank == Rank.Jack && newCards[3].Rank == Rank.Ace);
        }
    }

    [TestFixture]
    public class FiveCardHandRemovingPairOnSuit
    {
        [Test]
        public void RemoveOnePairSuited()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(4, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(30, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && newCards[2].Rank == Rank.Jack && newCards[3].Rank == Rank.Ace && newCards[3].Suit == Suit.Hearts);
        }

        [Test]
        public void RemoveTwoPairSuited()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(3, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(30, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[0].Suit == Suit.Hearts && newCards[1].Rank == Rank.Jack && newCards[2].Rank == Rank.Ace && newCards[2].Suit == Suit.Hearts);
        }
    }
}