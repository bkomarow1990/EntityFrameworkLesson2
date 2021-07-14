namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;

    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public virtual Country Country { get; set; }
    }
}