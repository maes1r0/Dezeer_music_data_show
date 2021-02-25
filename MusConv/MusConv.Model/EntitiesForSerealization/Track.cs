using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusConv.Model.EntitiesForSerealization
{
    public class Track
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }

    }
}
