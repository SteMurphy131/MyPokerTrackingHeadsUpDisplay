using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class SixCardHandRemovingThreeOfAKind
    {
        [Test]
        public void RemoveOne()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(4, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && newCards[2].Rank == Rank.Queen && newCards[3].Rank == Rank.Ace);
        }

        [Test]
        public void RemoveTwo()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(2, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Ace);
        }

        [Test]
        public void RemoveThreeAndPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(3, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && newCards[2].Rank == Rank.Ace);
        }

        [Test]
        public void RemoveThreeAndPair2()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();

            Assert.AreEqual(3, newCards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Six && newCards[1].Rank == Rank.Seven && newCards[2].Rank == Rank.Ace);
        }
    }
}