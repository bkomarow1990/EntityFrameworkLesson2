namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;

    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
        public virtual Category Category { get; set; }
    }
}