using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting
{
    [TestFixture]
    public class TurnEvaluationTesting
    {
        [Test]
        public void TurnEvaluationTestStraightFlush()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(score, Pokerscore.StraightFlush);
            Assert.Greater(35, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestFullHouse()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.FullHouse, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestFourOfAKind()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.FourOfAKind, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestFlush()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Flush, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestThreeOfAKind()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.ThreeOfAKind, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestStraight()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Straight, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestTwoPair()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.TwoPair, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestOnePair()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.Pair, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }

        [Test]
        public void TurnEvaluationTestNone()
        {
            var stop = new Stopwatch();

            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
            };
            stop.Start();

            var score = PokerEvaluator.CalculateTurnScore(cards);

            stop.Stop();

            Assert.AreEqual(Pokerscore.None, score);
            Assert.Greater(40, stop.ElapsedMilliseconds);
        }
    }
}