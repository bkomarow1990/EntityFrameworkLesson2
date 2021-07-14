namespace EntityFrameworkLesson2
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }

    }
}