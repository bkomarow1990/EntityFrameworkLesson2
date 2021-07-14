namespace EntityFrameworkLesson2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArtistId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AlbumId = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Playlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id)
                .Index(t => t.AlbumId)
                .Index(t => t.Playlist_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Playlists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Playlists", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Artists", "CountryId", "dbo.Countries");
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Playlists", new[] { "Artist_Id" });
            DropIndex("dbo.Playlists", new[] { "CategoryId" });
            DropIndex("dbo.Artists", new[] { "CountryId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Tracks");
            DropTable("dbo.Categories");
            DropTable("dbo.Playlists");
            DropTable("dbo.Countries");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
