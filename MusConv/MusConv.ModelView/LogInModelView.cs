using System;
using System.ComponentModel;
using MusConv.Model;
using Prism.Commands;
using Microsoft.Web.WebView2.Core;
using System.Windows;
using System.Windows.Interactivity;


namespace MusConv.ModelView
{
    public class LogInViewModel 
    {
        private ILogInModel logInModel = new LogInModel();
        private MainWindowViewModel mainWindowViewModel;

        public Uri UriSource { get => logInModel.userLogInUri; }
        public string RedirectUri { get => logInModel.RedirectUri; }
        public string RefreshToken { get => logInModel.RefreshToken; set => logInModel.RefreshToken = value; }
        public string AccessToken { get => logInModel.AccessToken; set => logInModel.AccessToken = value; }
        public string UserName { get => logInModel.GetUserNameAsync().Result; }
       
        public LogInViewModel(MainWindowViewModel mainWindowViewModel){ this.mainWindowViewModel = mainWindowViewModel; }
       
        public void OnNavigationStarting(Window sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (e !=null && e.Uri.ToString().Contains(RedirectUri + "/?code="))
            {
                string testingUri = e.Uri.ToString();
                RefreshToken = testingUri.Substring(testingUri.IndexOf('=') + 1);
                string result = logInModel.GetAccessTokenAsync(RefreshToken).Result;
                AccessToken = result.Substring(result.IndexOf('=') + 1, result.IndexOf('&') - result.IndexOf('=') - 1);
                mainWindowViewModel.AccessToken = AccessToken;
                mainWindowViewModel.UserName = UserName;
                sender.Close();
            }
        }
            
            
            
            
            
            
        



    }
}
