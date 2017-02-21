using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverFullHouseEvaluation
    {
        [Test]
        public void TwoPairToFullHouse()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateTurnScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(4, outs.FullHouse.Outs);
            Assert.AreEqual(false, outs.FullHouse.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void ThreeOfAKindToFullHouse()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateTurnScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(9, outs.FullHouse.Outs);
            Assert.AreEqual(false, outs.FullHouse.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}