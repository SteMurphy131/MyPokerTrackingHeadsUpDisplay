﻿using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnStraightOutsideRunnerRunnerOuts
    {
        [Test]
        public void OutsideThreeDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(4, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(3) && joined.Contains(4) && joined.Contains(8) && joined.Contains(9));

            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(300, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawOneLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(3, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(1) && joined.Contains(5) && joined.Contains(6));

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(5) && joined.Contains(4));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawOneHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.King, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(3, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(14) && joined.Contains(10) && joined.Contains(9));

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, joined.Contains(11) && joined.Contains(10));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}