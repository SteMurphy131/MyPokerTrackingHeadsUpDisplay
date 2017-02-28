using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverStraightFlushOutsideOuts
    {
        [Test]
        public void TwoOutsideSFlush()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
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
        public void TwoOutsideSFlushWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
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
        public void TwoOutsideSFlushWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
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
        public void OneOutsideSFlushHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
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
        public void OneOutsideSFlushHighAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
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
        public void OneOutsideSFlushHighAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
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
        public void OneOutsideSFlushLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
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
        public void OneOutsideSFlushLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
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
        public void OneOutsideSFlushLowAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Two, Suit.Clubs),
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
    }
}