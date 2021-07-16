using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson2
{
    public class CoverImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        // Navigation properties 
        ICollection<Track> Tracks = new HashSet<Track>();
        ICollection<Playlist> Playlists = new HashSet<Playlist>();
    }
}
