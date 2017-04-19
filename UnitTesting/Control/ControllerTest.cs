using System.Diagnostics;
using System.Threading;
using MyPokerTrackingHeadsUpDisplay;
using NUnit.Framework;
using PokerStructures;
using PokerStructures.Enums;

namespace UnitTesting.Control
{
    [TestFixture]
    public class ControllerTest
    {
        readonly Stopwatch watch = new Stopwatch();

        [Test]
        public void TestFlowControl()
        {
            watch.Restart();
            Controller cont = Controller.Instance;
            cont.UpdateHoleEventCard(new Card(Rank.Ace, Suit.Clubs), 0);
            cont.UpdateHoleEventCard(new Card(Rank.Ace, Suit.Diamonds), 1);
            cont.UpdateBoardEventCard(new Card(Rank.Jack, Suit.Clubs), 0);
            cont.UpdateBoardEventCard(new Card(Rank.Ten, Suit.Clubs), 1);
            cont.UpdateBoardEventCard(new Card(Rank.Queen, Suit.Clubs), 2);
            watch.Stop();

            Assert.AreEqual(1, cont.Outs.RoyalFlush.Outs);
            Assert.AreEqual(9, cont.Outs.Flush.Outs);
            Assert.False(cont.Outs.Flush.RunnerRunner);
            Assert.Greater(1500, watch.ElapsedMilliseconds);

            watch.Restart();
            cont.UpdateBoardEventCard(new Card(Rank.Two, Suit.Clubs), 3);
            watch.Stop();

            Assert.AreEqual(1, cont.Outs.RoyalFlush.Outs);
            Assert.AreEqual(Pokerscore.Flush, cont.PokerScore);
            Assert.Greater(200, watch.ElapsedMilliseconds);

            watch.Restart();
            cont.UpdateBoardEventCard(new Card(Rank.King, Suit.Clubs), 4);
            watch.Stop();

            Assert.AreEqual(Pokerscore.RoyalFlush, cont.PokerScore);
            Assert.Greater(20, watch.ElapsedMilliseconds);
        }
    }
}