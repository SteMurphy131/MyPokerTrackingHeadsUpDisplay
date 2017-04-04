using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using MyPokerTrackingHeadsUpDisplay;
using NUnit.Framework;
using PokerStructures.Enums;
using UserStructures;

namespace UnitTesting.SessionData
{
    [TestFixture]
    public class SendingSessionData
    {
        private readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();
        private string _httpAddress = "http://localhost:51520/api/Data/AddSession";

        [Test]
        public void SendPassiveSession()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(144))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void SendPassiveSession2()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(120))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void SendMidSession()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(96))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void SendMidSession2()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(72))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void SendAggressiveSession()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(48))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void SendAggressiveSession2()
        {
            Session session = new Session
            {
                Username = "SteMurphy131",
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
                },
                Submitted = DateTime.UtcNow.Subtract(TimeSpan.FromHours(24))
            };

            session.Statistics.Calculate();

            var json = _serializer.Serialize(session);

            var httpRequest = (HttpWebRequest)WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
        }
    }
}