using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusConv.Model.EntitiesForSerealization
{
    public class Playlist
    {
        List<Track> tracks = new List<Track>();

        public List<Track> Tracks { get => tracks; set => tracks = value; }

        public Track this [int index] { get => tracks[index]; }
    }
}
