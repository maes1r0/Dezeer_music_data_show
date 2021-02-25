using System;
using System.Threading.Tasks;

namespace MusConv.Model
{
    public interface ILogInModel
    {
        Uri userLogInUri { get; }
        string RedirectUri { get; }
        string RefreshToken { get; set; }
        string AccessToken { get; set; }
        Task<string> GetAccessTokenAsync(string refreshToken);
        Task<string> GetUserNameAsync();
    }
}