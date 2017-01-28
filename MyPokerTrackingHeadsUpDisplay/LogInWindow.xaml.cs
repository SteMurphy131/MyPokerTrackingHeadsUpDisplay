using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public partial class LogInWindow : Window
    {
        public bool LoggedIn = false;

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButtonClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            User user = new User {UserName = username, Password = password, Email = "Email@Hotmail.com"};

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:64724/api/user/loginuser");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(user);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                LoggedIn = ProcessHttpReponse(result);
            }
        }

        private bool ProcessHttpReponse(string response)
        {
            return true;
        }
    }
}