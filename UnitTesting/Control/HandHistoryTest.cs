using MyPokerTrackingHeadsUpDisplay;
using NUnit.Framework;
using UserStructures;

namespace UnitTesting.Control
{
    [TestFixture]
    public class HandHistoryTest
    {
        [Test]
        public void TestHandHistory()
        {
            var history =
                "PokerStars Hand #168897984821:  Hold'em No Limit (50/100) - 2017/04/11 14:14:20 ET \nTable 'Riceia II' 9 - max(Play Money) Seat #2 is the button \nSeat 2: pecallorus (9019 in chips) \n" +
                "Seat 3: SteMurphy131 (9700 in chips) \nSeat 4: luisp66 (10471 in chips) \nSeat 5: feme81 (10440 in chips) \nSteMurphy131: posts small blind 50 \nluisp66: posts big blind 100 \n" +
                "*** HOLE CARDS*** \nDealt to SteMurphy131[Qs Ah] \nfeme81: calls 100 \npecallorus: calls 100 \nSteMurphy131: raises 500 to 600 \nluisp66: calls 500 \nfeme81: folds \n" +
                " pecallorus: folds \n*** FLOP *** [7d 3h 8d] \nSteMurphy131: checks \nfeme81 leaves the table \nluisp66: bets 300 \nSteMurphy131: calls 300 \n*** TURN *** [7d 3h 8d][9s] \n" +
                "SteMurphy131: checks \nluisp66: bets 955 \nSteMurphy131: folds \nUncalled bet(955) returned to luisp66 \nluisp66 collected 1910 from pot \nluisp66: doesn't show hand \n" +
                "*** SUMMARY *** \nTotal pot 2000 | Rake 90 \nBoard[7d 3h 8d 9s] \nSeat 2: pecallorus(button) folded before Flop \nSeat 3: SteMurphy131(small blind) folded on the Turn \n" +
                "Seat 4: luisp66(big blind) collected(1910) \nSeat 5: feme81 folded before Flop";

            MessageHandler handler = new MessageHandler();
            handler.Controller.User = new User {UserName = "SteMurphy131"};

            handler.HandleHandHistory(history);

            Assert.True(handler.Controller.Opponents.ContainsKey("pecallorus"));
            Assert.True(handler.Controller.Opponents.ContainsKey("luisp66"));
            Assert.True(handler.Controller.Opponents.ContainsKey("feme81"));

            Assert.AreEqual(handler.Controller.Opponents["pecallorus"].HandsPlayed, 1);
            Assert.AreEqual(handler.Controller.Opponents["luisp66"].HandsPlayed, 1);
            Assert.AreEqual(handler.Controller.Opponents["feme81"].HandsPlayed, 1);
        }
    }
}