using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson2
{
    public class ViewModel
    {
        public MusicalCollection db { get; set; } = new MusicalCollection();
        public HashSet<Track> Tracks { get; set; }
        public Track SelectedTrack { get; set; } = null;
        public Playlist SelectedPlaylist { get; set; } = null;
        public HashSet<Playlist> Playlists { get; set; }
        public ViewModel( )
        {
            Tracks = db.Tracks.ToHashSet();
            Playlists = db.Playlists.ToHashSet();
            db.Tracks.ToList();
            //db.CoverImages.Add(new CoverImage { Path = "https://i0.wp.com/itc.ua/wp-content/uploads/2019/09/Apple-Music-Android.jpg" });
            db.SaveChanges();
        }
    }
}
