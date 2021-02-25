using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MusConv.Model.EntitiesForSerealization;

namespace MusConv.Model
{
    public class LogInModel : ILogInModel
    {
        private const int appId = 461422;
        private const string perms = "basic_access,email,offline_access";
        private const string appSecret = "777549cecb816c21db2fca0478eed61a";
        private string refreshToken;
        private string accessToken;
        private HttpClient client = new HttpClient();

        public string RedirectUri { get => "https://www.google.com"; }
        public string RefreshToken { get => refreshToken; set => refreshToken = value; }
        public string AccessToken { get => accessToken; set => accessToken = value; }
        public Uri userLogInUri { get => new Uri("https://connect.deezer.com/oauth/auth.php?app_id=" + appId + "&redirect_uri=" + RedirectUri + "&perms=" + perms); }
        public async Task<string> GetAccessTokenAsync(string refreshToken)
        {

            HttpResponseMessage response = client.GetAsync("https://connect.deezer.com/oauth/access_token.php?app_id="
                + appId + "&secret=" + appSecret + "&code=" + refreshToken).Result;

            string accessToken = await response.Content.ReadAsStringAsync();
            return accessToken;
        }
        public async Task<string> GetUserNameAsync()
        {
            HttpResponseMessage response = client.GetAsync("https://api.deezer.com/user/me?"+"access_token=" + AccessToken).Result;
            User currentUser = await response.Content.ReadFromJsonAsync<User>();
            return currentUser.Name;
        }
    }
}

