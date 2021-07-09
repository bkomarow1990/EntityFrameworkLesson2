namespace EntityFrameworkLesson2
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MusicalCollection : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EntityFrameworkLesson2.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public MusicalCollection()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Country> Countries { get; set; }
         public virtual DbSet<Genre> Genres { get; set; }
         public virtual DbSet<Category  > Categories { get; set; }
         public virtual DbSet<Artist  > Artists { get; set; }
         public virtual DbSet<Album> Albums { get; set; }
         public virtual DbSet<Track> Tracks { get; set; }
         public virtual DbSet<Playlist> Playlists{ get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
    }
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
    }
    public class Track
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public int CategoryId { get; set; }
    }
}