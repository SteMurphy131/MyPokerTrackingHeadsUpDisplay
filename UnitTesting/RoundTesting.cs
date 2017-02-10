using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting
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
        public void TestRoundClearing()
        {
            Round round = new Round();
            Card card1 = new Card(Rank.Ace, Suit.Clubs);
            Card card2 = new Card(Rank.Ten, Suit.Clubs);
            Card card3 = new Card(Rank.Six, Suit.Clubs);


            round.SetFlopCard(card1, 0);
            round.SetTurnCard(card2);
            round.SetRiverCard(card3);

            round.ClearRoundData();

            Assert.AreEqual(round.Turn, null);
            Assert.AreEqual(round.River, null);
        }
    }
}