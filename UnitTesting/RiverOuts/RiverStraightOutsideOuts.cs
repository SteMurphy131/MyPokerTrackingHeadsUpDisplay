using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;

namespace UnitTesting.RiverOuts
{
    [TestFixture]
    public class RiverStraightOutsideOuts
    {
        [Test]
        public void OutsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();
            
            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Six, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(8, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithHighAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithHighAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithLowAceWithPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightDrawWithLowAceWithTwoPair()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            var score = PokerEvaluator.CalculateFlopScore(hand.Cards);
            var outs = PokerOutsCalculator.CalculateRiverOuts(hand, score);
            watch.Stop();

            Assert.AreEqual(4, outs.Straight.Outs);
            Assert.Greater(200, watch.ElapsedMilliseconds);
        }
    }
}