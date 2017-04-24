using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class HttpSender
    {
        private readonly Controller _controller;
        private readonly JavaScriptSerializer _serializer;
        private string _sessionAddAddress = "http://pokerhudweb.azurewebsites.net/api/data/addsession";

        public HttpSender(Controller con)
        {
            _controller = con;
            _serializer = new JavaScriptSerializer();
        }

        public void Send()
        {
            _controller.Session.Statistics.Calculate();

            try
            {
                var json = _serializer.Serialize(_controller.Session);
                var oppJson = _serializer.Serialize(_controller.Opponents.Values);

                _controller.Log.Info($"Session Data: {json}");

                var sessionAddRequest = (HttpWebRequest)WebRequest.Create(_sessionAddAddress);
                sessionAddRequest.ContentType = "application/json";
                sessionAddRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(sessionAddRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var sessionResponse = (HttpWebResponse)sessionAddRequest.GetResponse();

                using (var streamReader = new StreamReader(sessionResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                _controller.Log.Error(e);
            }
        }
    }
}