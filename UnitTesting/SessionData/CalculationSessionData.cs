using NUnit.Framework;
using PokerStructures.Enums;
using UserStructures;

namespace UnitTesting.SessionData
{
    [TestFixture]
    public class CalculationSessionData
    {
        [Test]
        public void CalculatePassiveData()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 320,
                    HandsWon = 28,
                    HandsFoldedBeforeFlop = 240,
                    HandsFoldedBeforeRiver = 30,
                    HandsPlayedToRiver = 50,
                    HandsWonBeforeFlop = 2,
                    HandsWonBeforeRiver = 2,
                    HandsWonAtRiver = 24,
                    PreFlopRaises = 15,
                    PreFlopRaiseWin = 6,
                    ContinuationBets = 3,
                    ContinuationBetsWin = 1,
                    VoluntaryPutInPot = 85,
                    VpipWin = 30,
                    TotalBets = 20,
                    TotalRaises = 65,
                    TotalCalls = 140,
                    TotalFolds = 120,
                    TotalChecks = 140
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Passive);
        }

        [Test]
        public void CalculatePassiveData2()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 300,
                    HandsWon = 30,
                    HandsFoldedBeforeFlop = 220,
                    HandsFoldedBeforeRiver = 30,
                    HandsPlayedToRiver = 50,
                    HandsWonBeforeFlop = 2,
                    HandsWonBeforeRiver = 4,
                    HandsWonAtRiver = 24,
                    PreFlopRaises = 20,
                    PreFlopRaiseWin = 8,
                    ContinuationBets = 5,
                    ContinuationBetsWin = 5,
                    VoluntaryPutInPot = 75,
                    VpipWin = 30,
                    TotalBets = 20,
                    TotalRaises = 80,
                    TotalCalls = 120,
                    TotalFolds = 140,
                    TotalChecks = 130
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Passive);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Passive);
        }

        [Test]
        public void CalculateMidData()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 300,
                    HandsWon = 35,
                    HandsFoldedBeforeFlop = 220,
                    HandsFoldedBeforeRiver = 30,
                    HandsPlayedToRiver = 50,
                    HandsWonBeforeFlop = 2,
                    HandsWonBeforeRiver = 4,
                    HandsWonAtRiver = 24,
                    PreFlopRaises = 55,
                    PreFlopRaiseWin = 20,
                    ContinuationBets = 25,
                    ContinuationBetsWin = 15,
                    VoluntaryPutInPot = 70,
                    VpipWin = 30,
                    TotalBets = 40,
                    TotalRaises = 80,
                    TotalCalls = 90,
                    TotalFolds = 140,
                    TotalChecks = 130
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Mid);
        }

        [Test]
        public void CalculateMidData2()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 400,
                    HandsWon = 35,
                    HandsFoldedBeforeFlop = 310,
                    HandsFoldedBeforeRiver = 30,
                    HandsPlayedToRiver = 50,
                    HandsWonBeforeFlop = 4,
                    HandsWonBeforeRiver = 6,
                    HandsWonAtRiver = 25,
                    PreFlopRaises = 60,
                    PreFlopRaiseWin = 25,
                    ContinuationBets = 35,
                    ContinuationBetsWin = 15,
                    VoluntaryPutInPot = 80,
                    VpipWin = 30,
                    TotalBets = 50,
                    TotalRaises = 90,
                    TotalCalls = 90,
                    TotalFolds = 80,
                    TotalChecks = 90
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Mid);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Mid);
        }

        [Test]
        public void CalcaulateAggressiveData()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 345,
                    HandsWon = 30,
                    HandsFoldedBeforeFlop = 250,
                    HandsFoldedBeforeRiver = 25,
                    HandsPlayedToRiver = 75,
                    HandsWonBeforeFlop = 4,
                    HandsWonBeforeRiver = 6,
                    HandsWonAtRiver = 20,
                    PreFlopRaises = 52,
                    PreFlopRaiseWin = 27,
                    ContinuationBets = 45,
                    ContinuationBetsWin = 25,
                    VoluntaryPutInPot = 60,
                    VpipWin = 30,
                    TotalBets = 70,
                    TotalRaises = 110,
                    TotalCalls = 50,
                    TotalFolds = 20,
                    TotalChecks = 30
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Aggressive);
        }

        [Test]
        public void CalculateAggressiveData2()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 367,
                    HandsWon = 32,
                    HandsFoldedBeforeFlop = 250,
                    HandsFoldedBeforeRiver = 25,
                    HandsPlayedToRiver = 75,
                    HandsWonBeforeFlop = 4,
                    HandsWonBeforeRiver = 3,
                    HandsWonAtRiver = 25,
                    PreFlopRaises = 58,
                    PreFlopRaiseWin = 27,
                    ContinuationBets = 45,
                    ContinuationBetsWin = 25,
                    VoluntaryPutInPot = 60,
                    VpipWin = 28,
                    TotalBets = 90,
                    TotalRaises = 110,
                    TotalCalls = 45,
                    TotalFolds = 10,
                    TotalChecks = 20
                }
            };

            session.Statistics.Calculate();

            Assert.AreEqual(session.Statistics.PfrStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.CBetStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggFreqStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggFactStyle, PlayingStyle.Aggressive);
            Assert.AreEqual(session.Statistics.AggPercStyle, PlayingStyle.Aggressive);
        }
    }
}