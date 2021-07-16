namespace EntityFrameworkLesson2
{
    using System.Data.Entity;
    using System.Linq;

    public class MusicalCollection : DbContext
    {
        public MusicalCollection()
            : base("name=MusicalCollectionDB")
        {
            Database.SetInitializer<MusicalCollection>(new Initializer());
            //Database.Initialize(true);
        }
        static MusicalCollection()
        {
           
            
        }

         public virtual DbSet<Country> Countries { get; set; }
         public virtual DbSet<Genre> Genres { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
         public virtual DbSet<Artist> Artists { get; set; }
         public virtual DbSet<Album> Albums { get; set; }
         public virtual DbSet<Track> Tracks { get; set; }
         public virtual DbSet<Playlist> Playlists{ get; set; }
         public virtual DbSet<CoverImage> CoverImages { get; set; }
    }
}