using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class SixCardHandRemovingPairs
    {
        [Test]
        public void RemoveThreePair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(3, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Queen && 
                                  newCards[2].Rank == Rank.Ace);
        }

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
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(4, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Jack && 
                                  newCards[2].Rank == Rank.Queen && newCards[3].Rank == Rank.Ace);
        }

        [Test]
        public void RemovePair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(5, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && 
                                  newCards[2].Rank == Rank.Jack && newCards[3].Rank == Rank.Queen && 
                                  newCards[4].Rank == Rank.Ace);
        }
    }
}