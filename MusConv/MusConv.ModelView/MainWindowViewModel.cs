using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusConv.Model;
using MusConv.Model.EntitiesForSerealization;
using System.ComponentModel;
using Prism.Commands;
using System.Windows;

namespace MusConv.ModelView
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        IMainWindowModel mainWindowModel = new MainWindowModel();
        public event PropertyChangedEventHandler PropertyChanged;
        private string userName;
        public DelegateCommand GetPlaylistsCommand { get; set; }
        public DelegateCommand GetFolowedArtistsCommand { get; set; }
        public DelegateCommand GetLikedAlbumCommand { get; set; }
        public DelegateCommand GetLikedTracksCommand { get; set; }
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public MainWindowViewModel()
        {
            GetPlaylistsCommand = new DelegateCommand(() =>
            {
                List<Playlist> playlists = mainWindowModel.GetPlaylistsAsync().Result;
            }); 
        }
        public DelegateCommand TextInputCommand { get; }
        public string AccessToken { get => mainWindowModel.AccessToken; set => mainWindowModel.AccessToken = value; }
    }
}
