using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverStraightFlushOutsEvaluation
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(1, outsideDraw);
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(1, outsideDraw);
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneOutsideSFlush()
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
            int outsideDraw = hand.CountOutsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(2, outsideDraw);
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
            int outsideDraw = hand.CountOutsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(1, outsideDraw);
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
            int outsideDraw = hand.CountOutsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(1, outsideDraw);
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(2, outsideDraw);
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(2, outsideDraw);
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
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}