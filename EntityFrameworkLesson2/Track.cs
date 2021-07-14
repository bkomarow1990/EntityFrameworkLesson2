namespace EntityFrameworkLesson2
{
    using System;
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
        public virtual Album Album { get; set; }
    }
}