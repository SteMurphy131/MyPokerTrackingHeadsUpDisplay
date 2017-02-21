using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enumeration;
using PokerStructures.Enums;

namespace UnitTesting.Enumeration
{
    [TestFixture]
    public class EnumerationTesting
    {
        [Test]
        public void CombinationTestingFiveFromSix()
        {
            int count = 0;
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Six, Suit.Diamonds),
            };

            foreach (var comb in PokerEnumerator.GetCombinationsOfNMinusOne(cards, 5))
            {
                Assert.AreEqual(comb.Count(), 5);
                count++;
            }

            Assert.AreEqual(count, 6);
        }

        [Test]
        public void CombinationTestingFiveFromSeven()
        {
            int count = 0;
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Diamonds),
            };

            foreach (var comb in PokerEnumerator.GetCombinationsOfNMinusTwo(cards, 5))
            {
                Assert.AreEqual(comb.Count(), 5);
                count++;
            }

            Assert.AreEqual(21, count);
        }

        [Test]
        public void CombinationTestingThreeFromFive()
        {
            int count = 0;
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds)
            };

            foreach (var comb in PokerEnumerator.GetCombinationsOfNMinusTwo(cards, 3))
            {
                count++;
                Assert.AreEqual(comb.Count(), 3);
            }

            Assert.AreEqual(count, 10);
        }

        [Test]
        public void CombinationTestingFourFromFive()
        {
            int count = 0;
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds)
            };

            foreach (var comb in PokerEnumerator.GetCombinationsOfNMinusOne(cards, 4))
            {
                count++;
                Assert.AreEqual(comb.Count(), 4);
            }

            Assert.AreEqual(count, 5);
        }
    }
}