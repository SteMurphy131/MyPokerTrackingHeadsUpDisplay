using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnStraightFlushInsideRunnerRunnerOuts
    {
        [Test]
        public void SFlushMissingOne()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Six, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoLowDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Four, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneNoHighDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwo()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoLowDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoNoHighDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingOneTwice()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(false, outs.StraightFlush.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void SFlushMissingTwoTwice()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(.28, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }
    }
}