using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusConv.Model.EntitiesForSerealization;

namespace MusConv.Model
{
    public interface IMainWindowModel
    {
        string AccessToken { get; set; }
        Task<List<Playlist>> GetPlaylistsAsync();
        Task<List<Artist>> GetFolowedArtistsAsync();
        Task<List<Track>> GetLikedTracksAsync();
    }
}
