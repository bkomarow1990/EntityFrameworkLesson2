namespace EntityFrameworkLesson2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Track
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int Count_Listening { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return $"{Name}, Album: {Album.Name}, Rating: {Rating}, Duration: {Duration}, Listenings: {Count_Listening}"; 
        }
        public ICollection<Playlist> Playlists { get; set; }
        public virtual Album Album { get; set; }
    }
}