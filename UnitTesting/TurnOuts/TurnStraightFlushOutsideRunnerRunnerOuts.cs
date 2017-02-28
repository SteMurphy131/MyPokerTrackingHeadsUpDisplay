using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnStraightFlushOutsideRunnerRunnerOuts
    {
        [Test]
        public void OutsideThreeDrawSFlush()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.28, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.28, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.28, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneLowDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Two, Suit.Clubs),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Nine, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoLowDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Three, Suit.Diamonds),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushOneHighDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Jack, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawSFlushNoHighDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}