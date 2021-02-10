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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net.Http;


namespace MusConv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient generalClient = new HttpClient();
        private string requestUri = "https://api.deezer.com/user/me";
        public string AccessToken { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Owner = this;
            authWindow.Show();
            
            
        }

        private void playlistRequest_Click(object sender, RoutedEventArgs e)
        {
            string result = GetPlaylistsAsync().Result;
            MessageBox.Show(result);
        }
        private async Task<string> GetPlaylistsAsync()
        {
               HttpResponseMessage response = generalClient.GetAsync(requestUri + "/playlists?access_token=" + AccessToken).Result;
                string result = await response.Content.ReadAsStringAsync();
                return result;
        }

        private void folowedArtistsRequest_Click(object sender, RoutedEventArgs e)
        {
            string result = GetFolowedArtistsAsync().Result;
            MessageBox.Show(result);
        }
        private async Task<string> GetFolowedArtistsAsync()
        {
            HttpResponseMessage response = generalClient.GetAsync(requestUri + "/artists?access_token=" + AccessToken).Result;
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        private void likedAlbumRequest_Click(object sender, RoutedEventArgs e)
        {
            string result = GetLikedAlbumAsync().Result;
            MessageBox.Show(result);
        }
        private async Task<string> GetLikedAlbumAsync()
        {
            HttpResponseMessage response = generalClient.GetAsync(requestUri + "/albums?access_token=" + AccessToken).Result;
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
        private void LikedTrackRequest_Click(object sender, RoutedEventArgs e)
        {
            string result = GetLikedTrackAsync().Result;
            MessageBox.Show(result);
        }
        private async Task<string> GetLikedTrackAsync()
        {
            HttpResponseMessage response = generalClient.GetAsync(requestUri + "/tracks?access_token=" + AccessToken).Result;
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
