using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverStraightFlushInsideOuts
    {
        [Test]
        public void OneInsideSFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushHighAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushHighAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideSFlushLowAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Two, Suit.Spades),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
        
        [Test]
        public void TwoInsideSFlush()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideSFlushWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideSFlushLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideSFlushLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Four, Suit.Spades),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideSFlushHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
        [Test]
        public void TwoInsideSFlushHighAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Nine, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}