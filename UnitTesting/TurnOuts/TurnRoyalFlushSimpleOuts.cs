using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnRoyalFlushSimpleOuts
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
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(0, outs.RoyalFlush.Outs);
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
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideRFlushDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);
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
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void InsideRFlushDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Diamonds),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.RoyalFlush.Outs);
            Assert.AreEqual(false, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}