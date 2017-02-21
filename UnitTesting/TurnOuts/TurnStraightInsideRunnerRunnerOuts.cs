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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(3, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(4) && missingOne.Contains(7) && missingOne.Contains(9));

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(3) && missingOne.Contains(5));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            
            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(2, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(10) && missingOne.Contains(13));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(6) && missingTwo.Contains(7));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(2) && missingTwo.Contains(3));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(12) && missingTwo.Contains(13));

            Assert.AreEqual(1.48, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(4, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(2) && missingOne.Contains(4) && missingOne.Contains(7));
            Assert.AreEqual(true, missingTwo.Contains(7) && missingTwo.Contains(9));

            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(3, missingOne.Count);
            Assert.AreEqual(2, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(2) && missingOne.Contains(4) && missingOne.Contains(7));
            Assert.AreEqual(true, missingTwo.Contains(7) && missingTwo.Contains(8));

            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(4, missingOne.Count);
            Assert.AreEqual(0, missingTwo.Count);
            Assert.AreEqual(true, missingOne.Contains(2) && missingOne.Contains(4) && missingOne.Contains(7) && missingOne.Contains(10));

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var joined = hand.CountThreeOpenEndedJoinedCards();
            var missingOne = hand.CountThreeCardMissingOneMiddle();
            var missingTwo = hand.CountThreeCardMissingTwoMiddle();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(0, joined.Count);
            Assert.AreEqual(0, missingOne.Count);
            Assert.AreEqual(4, missingTwo.Count);
            Assert.AreEqual(true, missingTwo.Contains(4) && missingTwo.Contains(5) && missingTwo.Contains(8) && missingTwo.Contains(9));

            Assert.AreEqual(4.44, outs.Straight.Percentage);
            Assert.AreEqual(true, outs.Straight.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void EvenlySpacedCards()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Ten, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(2.96, outs.Straight.Percentage);
            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
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

            var score = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);

            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.AreEqual(false, outs.Straight.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}