using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverPairOuts
    {
        [Test]
        public void NothingToPairOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Nine, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateTurnScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(18, outs.Pair.Outs);
            Assert.AreEqual(false, outs.Pair.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}