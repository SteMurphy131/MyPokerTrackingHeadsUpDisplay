using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnTwoPairOutsEvaluation
    {
        [Test]
        public void NothingToTwoPairOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(8.33, outs.TwoPair.Percentage);
            Assert.AreEqual(true, outs.TwoPair.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void PairToTwoPairOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(9, outs.TwoPair.Outs);
            Assert.AreEqual(false, outs.TwoPair.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}