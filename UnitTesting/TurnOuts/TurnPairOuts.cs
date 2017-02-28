using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.TurnOuts
{
    [TestFixture]
    public class TurnPairOuts
    {
        [Test]
        public void NothingToPairOuts()
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
            var current = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateTurnOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(15, outs.Pair.Outs);
            Assert.AreEqual(false, outs.Pair.RunnerRunner);

            Assert.AreEqual(8, outs.Straight.Outs);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}