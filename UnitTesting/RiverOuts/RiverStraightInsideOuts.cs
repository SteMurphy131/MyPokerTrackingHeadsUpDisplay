using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverStraightInsideOuts
    {
        [Test]
        public void TwoInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithLowAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Two, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightDrawWithLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightDrawWithLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithHighAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithHighAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void NoInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(0, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}