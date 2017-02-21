using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverFlushOutsEvaluation
    {
        [Test]
        public void FourToAFlushOuts()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateTurnScore(hand.Hand);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(9, outs.Flush.Outs);
            Assert.AreEqual(false, outs.Flush.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}