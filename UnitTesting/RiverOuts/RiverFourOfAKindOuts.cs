using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverFourOfAKindOuts
    {
        [Test]
        public void ThreeOfAKindToFour()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var current = PokerEvaluator.CalculateTurnScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, current);
            watch.Stop();

            Assert.AreEqual(1, outs.FourOfAKind.Outs);
            Assert.AreEqual(false, outs.FourOfAKind.RunnerRunner);

            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}