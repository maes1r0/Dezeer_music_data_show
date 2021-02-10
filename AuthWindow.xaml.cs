using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Net.Http;

namespace MusConv
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private string appId = "461422";
        private string redirectUri = "https://www.google.com";
        private string perms = "basic_access,email,offline_access";
        private string appSecret = "777549cecb816c21db2fca0478eed61a";
        HttpClient getAccessToken = new HttpClient();

        public static string RefreshToken { get; set; }
        public static string AccessToken { get; set; }
        public AuthWindow()
        {
            InitializeComponent();
            deezerAuth.Source = new Uri("https://connect.deezer.com/oauth/auth.php?app_id=" + appId + "&redirect_uri=" + redirectUri + "&perms=" + perms);
        }


        private async Task<string> GetAccessToken(string refreshToken)
        {
            using (getAccessToken)
            {
                HttpResponseMessage response = getAccessToken.GetAsync("https://connect.deezer.com/oauth/access_token.php?app_id="
                    + appId + "&secret=" + appSecret + "&code=" + refreshToken).Result;

                string accessToken = await response.Content.ReadAsStringAsync();
                return accessToken;
            }
        }
    

        private void deezerAuth_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            string testingUri = e.Uri.ToString();
            if (testingUri.Contains(redirectUri + "/?code="))
            {
                RefreshToken = testingUri.Substring(testingUri.IndexOf('=') + 1);
                string result = GetAccessToken(RefreshToken).Result;
                AccessToken = result.Substring(result.IndexOf('=') + 1, result.IndexOf('&') - result.IndexOf('=') - 1);
                
                //MessageBox.Show(AccessToken);
                //deezerAuth.Dispose();
                this.Close();
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)(this.Owner)).AccessToken = AccessToken;
        }
    }
}
