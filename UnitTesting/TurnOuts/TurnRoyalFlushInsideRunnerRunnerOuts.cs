using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnRoyalFlushInsideRunnerRunnerOuts
    {
        [Test]
        public void RoyalFlushMissingOne()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCardsRoyalFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleRoyalFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleRoyalFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(11) && missingOne.Contains(14));

            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void RoyalFlushMissingTwo()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCardsRoyalFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleRoyalFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleRoyalFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(11) && missingTwo.Contains(12));

            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
        }

        [Test]
        public void RoyalFlushMissingOneNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCardsRoyalFlush();
            var missingOne = hand.CountThreeCardMissingOneMiddleRoyalFlush();
            var missingTwo = hand.CountThreeCardMissingTwoMiddleRoyalFlush();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(10) && missingOne.Contains(12));

            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);

            Assert.Greater(50, watch.ElapsedMilliseconds);
        }
    }
}