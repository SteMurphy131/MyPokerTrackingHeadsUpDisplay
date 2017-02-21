using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.Evaluation
{
    [TestFixture]
    public class RiverEvaluationTesting
    {
        [Test]
        public void TestRiverRoyalFlush()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.RoyalFlush, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverStraightFlush()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.StraightFlush, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverFourOfAKind()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.FourOfAKind, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverFullHouse()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Spades),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.FullHouse, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverFlush()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Flush, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverThreeOfAKind()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.ThreeOfAKind, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverStraight()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Straight, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverTwoPair()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.TwoPair, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TestRiverOnePair()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Pair, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);

        }

        [Test]
        public void TestRiverNone()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Eight, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateRiverScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.None, score);
            Assert.Greater(60, stop.ElapsedMilliseconds);
        }
    }
}