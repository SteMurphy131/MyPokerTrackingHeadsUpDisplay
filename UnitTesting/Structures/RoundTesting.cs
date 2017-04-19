using System.Collections.Generic;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class RoundTesting
    {
        [Test]
        public void TestAddingFlopCardAtPositionOne()
        {
            Round round = new Round();
            Card card1 = new Card(Rank.Ace, Suit.Clubs);
            Card card2 = new Card(Rank.Ten, Suit.Clubs);
            Card card3 = new Card(Rank.Six, Suit.Clubs);


            round.SetFlopCard(card1, 0);
            round.SetFlopCard(card2, 1);
            round.SetFlopCard(card3, 2);

            Assert.AreEqual(round.Flop[0], card1);
            Assert.AreEqual(round.Flop[1], card2);
            Assert.AreEqual(round.Flop[2], card3);
        }

        [Test]
        public void TestAddingHoleCards()
        {
            Round round = new Round();
            Card card1 = new Card(Rank.Ten, Suit.Hearts);
            Card card2 = new Card(Rank.King, Suit.Hearts);

            round.SetHoleCard(card1,0);
            round.SetHoleCard(card2,1);

            Assert.AreEqual(round.Hole[0], card1);
            Assert.AreEqual(round.Hole[1], card2);
        }

        [Test]
        public void TestAddingTurnCard()
        {
            Round round = new Round();
            Card card = new Card(Rank.Queen, Suit.Clubs);

            round.SetTurnCard(card);

            Assert.AreEqual(round.Turn, card);
        }

        [Test]
        public void TestAddingRiverCard()
        {
            Round round = new Round();
            Card card = new Card(Rank.Queen, Suit.Clubs);

            round.SetRiverCard(card);

            Assert.AreEqual(round.River, card);
        }

        [Test]
        public void TestEqualRounds()
        {
            var round1 = new Round
            {
                Hole = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs) },
                    { 1,new Card(Rank.Nine, Suit.Diamonds) }
                },
                Flop = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Ace, Suit.Clubs) },
                    { 1,new Card(Rank.Four, Suit.Clubs) },
                    { 2,new Card(Rank.Ace, Suit.Diamonds)}
                },
                Turn = new Card(Rank.Two, Suit.Clubs),
                River = new Card(Rank.King, Suit.Clubs),
                AllCards = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    { 1,new Card(Rank.Nine, Suit.Diamonds) },
                    { 2,new Card(Rank.Ace, Suit.Clubs) },
                    { 3,new Card(Rank.Four, Suit.Clubs) },
                    {4,new Card(Rank.Ace, Suit.Diamonds) },
                    { 5,new Card(Rank.Two, Suit.Clubs) },
                    { 6,new Card(Rank.King, Suit.Clubs) }
                },
                State = PokerGameState.Show,
                PreFlopRaise = false,
                ContinuationBet = false,
                Won = true,
                HandNumber = "#12312313"
            };

            var round2 = new Round
            {
                Hole = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    {1, new Card(Rank.Nine, Suit.Diamonds)}
                },
                Flop = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Ace, Suit.Clubs)},
                    {1, new Card(Rank.Four, Suit.Clubs)},
                    {2, new Card(Rank.Ace, Suit.Diamonds)}
                },
                Turn = new Card(Rank.Two, Suit.Clubs),
                River = new Card(Rank.King, Suit.Clubs),
                AllCards = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    {1, new Card(Rank.Nine, Suit.Diamonds)},
                    {2, new Card(Rank.Ace, Suit.Clubs)},
                    {3, new Card(Rank.Four, Suit.Clubs)},
                    {4, new Card(Rank.Ace, Suit.Diamonds)},
                    {5, new Card(Rank.Two, Suit.Clubs)},
                    {6, new Card(Rank.King, Suit.Clubs)}
                },
                State = PokerGameState.Show,
                PreFlopRaise = false,
                ContinuationBet = false,
                Won = true,
                HandNumber = "#12312313"
            };

            Assert.AreEqual(true, round1.Equals(round2));
        }

        [Test]
        public void TestUnequalRounds()
        {
            var round1 = new Round
            {
                Hole = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs) },
                    { 1,new Card(Rank.Nine, Suit.Diamonds) }
                },
                Flop = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Ace, Suit.Clubs) },
                    { 1,new Card(Rank.Four, Suit.Clubs) },
                    { 2,new Card(Rank.Ace, Suit.Diamonds)}
                },
                Turn = new Card(Rank.Two, Suit.Clubs),
                River = new Card(Rank.King, Suit.Clubs),
                AllCards = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    { 1,new Card(Rank.Nine, Suit.Diamonds) },
                    { 2,new Card(Rank.Jack, Suit.Clubs) },
                    { 3,new Card(Rank.Four, Suit.Clubs) },
                    {4,new Card(Rank.Ace, Suit.Diamonds) },
                    { 5,new Card(Rank.Two, Suit.Clubs) },
                    { 6,new Card(Rank.King, Suit.Clubs) }
                },
                State = PokerGameState.Show,
                PreFlopRaise = false,
                ContinuationBet = false,
                Won = true,
                HandNumber = "#12312313"
            };

            var round2 = new Round
            {
                Hole = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    {1, new Card(Rank.Nine, Suit.Diamonds)}
                },
                Flop = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Ace, Suit.Clubs)},
                    {1, new Card(Rank.Four, Suit.Clubs)},
                    {2, new Card(Rank.Ace, Suit.Diamonds)}
                },
                Turn = new Card(Rank.Two, Suit.Clubs),
                River = new Card(Rank.King, Suit.Clubs),
                AllCards = new Dictionary<int, Card>
                {
                    {0, new Card(Rank.Six, Suit.Clubs)},
                    {1, new Card(Rank.Nine, Suit.Diamonds)},
                    {2, new Card(Rank.Ace, Suit.Clubs)},
                    {3, new Card(Rank.Four, Suit.Clubs)},
                    {4, new Card(Rank.Ace, Suit.Diamonds)},
                    {5, new Card(Rank.Two, Suit.Clubs)},
                    {6, new Card(Rank.King, Suit.Clubs)}
                },
                State = PokerGameState.Show,
                PreFlopRaise = false,
                ContinuationBet = false,
                Won = true,
                HandNumber = "#12312313"
            };

            Assert.AreEqual(false, round1.Equals(round2));
        }
    }
}