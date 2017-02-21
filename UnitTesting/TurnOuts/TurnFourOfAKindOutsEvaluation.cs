using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnFourOfAKindOutsEvaluation
    {
        [Test]
        public void PairToFourOfAKindOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(.09, outs.FourOfAKind.Percentage);
            Assert.AreEqual(true, outs.FourOfAKind.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void ThreeOfAKindToFourOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(1, outs.FourOfAKind.Outs);
            Assert.AreEqual(false, outs.FourOfAKind.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void FullHouseToFourOfAKindOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades)
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateFlopScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(1, outs.FourOfAKind.Outs);
            Assert.AreEqual(false, outs.FourOfAKind.RunnerRunner);

            Assert.Greater(250, watch.ElapsedMilliseconds);
        }
    }
}