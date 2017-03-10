using NUnit.Framework;
using UserStructures;

namespace UnitTesting.Structures
{
    [TestFixture]
    public class SessionStatisticsTest
    {
        [Test]
        public void CalculatingStatistics()
        {
            var session = new Session();
            var stats = new SessionStatistics()
            {
                HandsPlayed = 20,
                PreFlopRaises = 10,
                PreFlopRaiseWin = 5,
                ContinuationBets = 8,
                ContinuationBetsWin = 4
            };

            session.Statistics = stats;

            session.Statistics.Calculate();

            Assert.AreEqual(50, session.Statistics.PreFlopRaisePercentage);
            Assert.AreEqual(50, session.Statistics.PreFlopRaiseWinPercentage);
            Assert.AreEqual(50, session.Statistics.ContinuationBetWinPercentage);
        }
    }
}