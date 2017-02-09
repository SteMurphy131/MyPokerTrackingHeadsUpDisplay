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
    public partial class LogInWindow
    {
        public User User { get; set; }

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButtonClick(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            User user = new User {UserName = username, ConfirmPassword = password, Password = password, Email = "Email@Hotmail.com", ConfirmEmail = "Email@Hotmail.com"};

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:64724/api/user/LogInUserApi");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(user);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
            if (ProcessHttpReponse(httpResponse))
                Close();
        }

        private bool ProcessHttpReponse(HttpWebResponse response)
        {
            if (response.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    User = new JavaScriptSerializer().Deserialize<User>(result);
                    return true;
                }       
            }

            return false;
        }
    }
}