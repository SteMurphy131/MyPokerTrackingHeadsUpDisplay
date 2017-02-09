using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting
{
    [TestFixture]
    public class RiverStraightOutsEvaluationTesting
    {
        [Test]
        public void NoRoyalFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int outsideDraw = hand.CountOutsideRoyalFlushDraws();
            watch.Stop();

            Assert.AreEqual(0, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideRoyalFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int outsideDraw = hand.CountOutsideRoyalFlushDraws();
            watch.Stop();

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void InsideRoyalFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int inside = hand.CountInsideRoyalFlushDraws();
            watch.Stop();

            Assert.AreEqual(1, inside);
            Assert.Greater(25, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OutsideStraightFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int outsideDraw = hand.CountOutsideStraightFlushDraws();
            watch.Stop();

            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightFlushDraws()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            watch.Stop();

            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightFlushDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int outsideDraw = hand.CountInsideStraightFlushDraws();
            watch.Stop();

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

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
            int outsideDraw = hand.CountOutsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(2, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
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
            int outsideDraw = hand.CountOutsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
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
            int outsideDraw = hand.CountOutsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(1, outsideDraw);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(2, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(1, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(1, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void TwoInsideStraightDrawWithLowAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(2, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void OneInsideStraightDrawWithHighAce()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(1, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }

        [Test]
        public void NoInsideStraightDraw()
        {
            Stopwatch watch = new Stopwatch();
            List<Card> cards = new List<Card>
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ten, Suit.Diamonds),
            };

            SixCardHand hand = new SixCardHand(cards);
            hand.Sort();

            watch.Start();
            int insideDraws = hand.CountInsideStraightDraws();
            watch.Stop();

            Assert.AreEqual(0, insideDraws);
            Assert.Greater(15, watch.ElapsedMilliseconds);
        }
    }
}