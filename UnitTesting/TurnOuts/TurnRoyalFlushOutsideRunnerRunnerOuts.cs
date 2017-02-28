using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnRoyalFlushOutsideRunnerRunnerOuts
    {
        [Test]
        public void OutsideThreeDrawRFlush()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawRFlushNoHighDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideThreeDrawRFlushNoLowDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(.09, outs.RoyalFlush.Percentage);
            Assert.AreEqual(true, outs.RoyalFlush.RunnerRunner);
            Assert.Greater(30, watch.ElapsedMilliseconds);
        }
    }
}