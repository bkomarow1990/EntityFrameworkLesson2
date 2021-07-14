namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();


    }
}