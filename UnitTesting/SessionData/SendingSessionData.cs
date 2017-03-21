using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using MyPokerTrackingHeadsUpDisplay;
using NUnit.Framework;
using UserStructures;

namespace UnitTesting.SessionData
{
    [TestFixture]
    public class SendingSessionData
    {
        private readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();
        private string _httpAddress = "http://localhost:51520/api/Data/AddSession";

        [Test]
        public void SendSessionData()
        {
            Session session = new Session
            {
                Username = "stephen",
                Statistics = new SessionStatistics
                {
                    HandsPlayed = 390,
                    HandsWon = 50,
                    HandsFoldedBeforeFlop = 300,
                    PreFlopRaises = 50,
                    PreFlopRaiseWin = 28,
                    VoluntaryPutInPot = 60,
                    VpipWin = 40,
                    ContinuationBets = 48,
                    ContinuationBetsWin = 45,
                    TotalRaises = 137,
                    TotalBets = 46,
                    TotalCalls = 26,
                    TotalFolds = 110,
                    TotalChecks = 65
                }
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