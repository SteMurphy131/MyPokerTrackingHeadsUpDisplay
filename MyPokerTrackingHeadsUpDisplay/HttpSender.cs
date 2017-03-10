using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class HttpSender
    {
        private readonly Controller _controller;
        private readonly JavaScriptSerializer _serializer;
        private string _httpAddress = "http://localhost:64724/api/user/AddSession";

        public HttpSender(Controller con)
        {
            _controller = con;
            _serializer = new JavaScriptSerializer();
        }

        public void Send()
        {
            _controller.Session.Statistics.Calculate();

            var json = _serializer.Serialize(_controller.Session);

            var httpRequest = (HttpWebRequest) WebRequest.Create(_httpAddress);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse) httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}