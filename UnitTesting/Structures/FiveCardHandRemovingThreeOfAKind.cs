using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class FiveCardHandRemovingThreeOfAKind
    {
        [Test]
        public void RemoveThreeOfAKind()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Jack, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(3, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Seven && newCards[1].Rank == Rank.Jack && newCards[2].Rank == Rank.Ace);
        }

        [Test]
        public void RemoveThreeAndPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts),
            };

            FiveCardHand hand = new FiveCardHand(cards);
            hand.Sort();
            watch.Start();
            var newCards = hand.RemovePairs();
            watch.Stop();


            Assert.AreEqual(2, newCards.Count);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.Greater(10, watch.ElapsedMilliseconds);
            Assert.AreEqual(true, newCards[0].Rank == Rank.Seven && newCards[1].Rank == Rank.Ace);
        }
    }
}