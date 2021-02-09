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
        private string appId = "app_id=461422&";
        private string redirectUri = "redirect_uri=https://www.google.com&";
        private string perms = "perms=basic_access,email,offline_access";
        private string appSecret = "secret=777549cecb816c21db2fca0478eed61a&";

        public static string refreshToken { get; set; }
        public static string accessToken { get; set; }
        public AuthWindow()
        {
            InitializeComponent();
            deezerAuth.Source = new Uri("https://connect.deezer.com/oauth/auth.php?" + appId + redirectUri + perms);
        }

        
        private async Task<string> GetAccessToken (string refreshToken)
        {
            using (HttpClient getAccessToken = new HttpClient())
            {
               HttpResponseMessage response = getAccessToken.GetAsync("https://connect.deezer.com/oauth/access_token.php?" + appId + appSecret + refreshToken).Result;

                string accessToken = await response.Content.ReadAsStringAsync();
                return accessToken;
            }


                
        }

        private void deezerAuth_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            string testingUri = e.Uri.ToString();
            if (testingUri.Contains("https://www.google.com/?code="))
            {
                this.Visibility = Visibility.Hidden;
                refreshToken = testingUri.Substring(testingUri.IndexOf("code"));
                accessToken = GetAccessToken(refreshToken).Result;
                accessToken = accessToken.Substring(accessToken.IndexOf('=') + 1, accessToken.IndexOf('&') - accessToken.IndexOf('=') - 1);
                MessageBox.Show(accessToken);
                this.Close();
                
            }
        }
    }
}
