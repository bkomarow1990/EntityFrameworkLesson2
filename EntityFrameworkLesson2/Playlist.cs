namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
        public int? CoverImageId { get; set; }

        public override string ToString()
        {
            return Name;
        }
        public virtual Category Category { get; set; }
        public virtual CoverImage CoverImage { get; set; }
    }
}