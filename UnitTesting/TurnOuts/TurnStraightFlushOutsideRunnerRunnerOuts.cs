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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(4, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(2) && joined.Contains(3) && joined.Contains(7) && joined.Contains(8));

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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(3, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(1) && joined.Contains(5) && joined.Contains(6));

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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(4) && joined.Contains(5));

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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(3, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(14) && joined.Contains(10) && joined.Contains(9));

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

            var joined = hand.CountThreeOpenEndedJoinedCardsStraightFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleStraightFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleStraightFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(10) && joined.Contains(11));

            Assert.AreEqual(.09, outs.StraightFlush.Percentage);
            Assert.AreEqual(true, outs.StraightFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}