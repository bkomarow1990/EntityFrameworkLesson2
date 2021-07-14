using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson2
{
    public class Initializer : CreateDatabaseIfNotExists<MusicalCollection>
    {
        protected override void Seed(MusicalCollection db)
        {
            // Countries
            Country russia = new Country { Name = "Russia" };
            db.Countries.Add(russia);
            db.Countries.Add(new Country { Name = "USA"});
            Country ukraine = new Country { Name = "Italy" };
            db.Countries.Add(ukraine);
            db.Countries.Add(new Country { Name = "Ukraine"});
            db.Countries.Add(new Country { Name = "France"});
            db.Countries.Add(new Country { Name = "Switzerland"});
            db.Countries.Add(new Country { Name = "Belarus"});
            db.Countries.Add(new Country { Name = "Kazakhstan"});
            // Genres
            db.Genres.Add(new Genre { Name="Rap"});
            db.Genres.Add(new Genre { Name="Rock"});
            db.Genres.Add(new Genre { Name="Classic"});
            Genre shanson = new Genre { Name = "Shanson" };
            db.Genres.Add(shanson);
            // Caregories
            db.Categories.Add(new Category { Name="Test"});
            db.Categories.Add(new Category { Name="To gym"});
            db.Categories.Add(new Category { Name="Relax"});
            db.Categories.Add(new Category { Name="To pobuhat"});
            // Artists
            db.Artists.Add(new Artist { Name = "Stas", Surname = "Mikhaylow", Country = russia});
            db.Artists.Add(new Artist { Name = "Monatik", Surname = "Albertovich", Country = ukraine});
            db.Artists.Add(new Artist { Name = "Oleg", Surname = "Winnik", Country = ukraine});
            db.SaveChanges();
            // Albums
            Album top_album = new Album { Name = "Winnik LOVE",Rating = 10, Genre = shanson, Year = 2021, Artist = db.Artists.Where(e=> e.Name == "Oleg").First()};
            db.Albums.Add(top_album);
            //Tracks
            db.Tracks.Add(new Track { Name = "Молода Вовчиця", Rating = 10, Album = top_album , Duration = TimeSpan.FromMinutes(3)});
            db.Tracks.Add(new Track { Name = "Ніно", Album = top_album , Rating= 9, Duration = TimeSpan.FromMinutes(2)});
            //Playlists
            db.Playlists.Add(new Playlist { Name = "Grandpa playlist", Category = db.Categories.Where(e=> e.Name == "To pobuhat").First(), Tracks = db.Tracks.ToList()});
            db.SaveChanges();
             
        }
    }
}
