using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnStraightAndRoyalFlushOutEvaluationTesting
    {
        [Test]
        public void NoRFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int outsideDraw = hand.CountOutsideRoyalFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, outs.RoyalFlush.Outs);

            Assert.AreEqual(0, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideRFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int outsideDraw = hand.CountOutsideRoyalFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void InsideRFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int inside = hand.CountInsideRoyalFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);

            Assert.AreEqual(1, inside);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideSFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int outsideDraw = hand.CountOutsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(false, outs.StraightFlush.RunnerRunner);

            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideSFlushDraws()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, outs.StraightFlush.Outs);
            Assert.AreEqual(false, outs.StraightFlush.RunnerRunner);

            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

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
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            int outsideDraw = hand.CountInsideStraightFlushDraws();
            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(false, outs.StraightFlush.RunnerRunner);

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}