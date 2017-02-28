using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnStraightInsideRunnerRunnerOuts
    {
        [Test]
        public void MissingOne()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneNoLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneNoHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwo()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoNoLowDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoNoHighDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneAndMissingTwo()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneAndMissingTwo2()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingOneTwice()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void MissingTwoTwice()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeAndMissingOneFindsSimpleOut()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Eight, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeAndMissingTwoFindsSimpleOut()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Nine, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);
            Assert.Greater(250, watch.ElapsedMilliseconds);
        }
    }
}