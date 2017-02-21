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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(3, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(4) && missingOne.Contains(7) && missingOne.Contains(9));

            Assert.AreEqual(.19, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(2) && missingOne.Contains(5));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(10) && missingOne.Contains(13));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(4) && missingTwo.Contains(5));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(2) && missingTwo.Contains(3));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(12) && missingTwo.Contains(13));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(4, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(2) && missingOne.Contains(4) && missingOne.Contains(7) && missingOne.Contains(10));

            Assert.AreEqual(1, outs.StraightFlush.Outs);
            Assert.AreEqual(false, outs.StraightFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(4, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(4) && missingTwo.Contains(5) && missingTwo.Contains(8) && missingTwo.Contains(9));

            Assert.AreEqual(.28, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
        }
    }
}