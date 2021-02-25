using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusConv.Model.EntitiesForSerealization;
using System.Net.Http;
using System.Net.Http.Json;

namespace MusConv.Model
{
    public class MainWindowModel : IMainWindowModel
    {
        public string AccessToken { get; set; }
        private const string requestUri = "https://api.deezer.com/user/me";
        private HttpClient client = new HttpClient();
        public async Task<List<Playlist>> GetPlaylistsAsync ()
        {
            HttpResponseMessage response = client.GetAsync(requestUri + "/playlists?access_token=" + AccessToken).Result;
            List<Playlist> playlists = await response.Content.ReadFromJsonAsync<List<Playlist>>();
            return playlists;
        }
        public async Task<List<Artist>> GetFolowedArtistsAsync()
        {
            HttpResponseMessage response = client.GetAsync(requestUri + "/artists?access_token=" + AccessToken).Result;
            List<Artist> artists = await response.Content.ReadFromJsonAsync<List<Artist>>();
            return artists;
        }
        public async Task<List<Album>> GetLikedAlbumAsync()
        {
            HttpResponseMessage response = client.GetAsync(requestUri + "/albums?access_token=" + AccessToken).Result;
            List<Album> albums = await response.Content.ReadFromJsonAsync<List<Album>>();
            return albums;
        }
        public async Task<List<Track>> GetLikedTracksAsync()
        {
            HttpResponseMessage response = client.GetAsync(requestUri + "/tracks?access_token=" + AccessToken).Result;
            List<Track> tracks = await response.Content.ReadFromJsonAsync<List<Track>>();
            return tracks;
        }
    }
}
