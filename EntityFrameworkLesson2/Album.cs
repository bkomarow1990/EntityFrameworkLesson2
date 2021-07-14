namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;

    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public Genre Genre { get; set; }
    }
}