namespace EntityFrameworkLesson2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            CreateTable(
                "dbo.CoverImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackPlaylists",
                c => new
                    {
                        Track_Id = c.Int(nullable: false),
                        Playlist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_Id, t.Playlist_Id })
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id, cascadeDelete: true)
                .Index(t => t.Track_Id)
                .Index(t => t.Playlist_Id);
            
            AddColumn("dbo.Albums", "CoverImageId", c => c.Int());
            AddColumn("dbo.Playlists", "CoverImageId", c => c.Int());
            CreateIndex("dbo.Albums", "CoverImageId");
            CreateIndex("dbo.Playlists", "CoverImageId");
            AddForeignKey("dbo.Playlists", "CoverImageId", "dbo.CoverImages", "Id");
            AddForeignKey("dbo.Albums", "CoverImageId", "dbo.CoverImages", "Id");
            DropColumn("dbo.Tracks", "Playlist_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "Playlist_Id", c => c.Int());
            DropForeignKey("dbo.Albums", "CoverImageId", "dbo.CoverImages");
            DropForeignKey("dbo.TrackPlaylists", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.TrackPlaylists", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Playlists", "CoverImageId", "dbo.CoverImages");
            DropIndex("dbo.TrackPlaylists", new[] { "Playlist_Id" });
            DropIndex("dbo.TrackPlaylists", new[] { "Track_Id" });
            DropIndex("dbo.Playlists", new[] { "CoverImageId" });
            DropIndex("dbo.Albums", new[] { "CoverImageId" });
            DropColumn("dbo.Playlists", "CoverImageId");
            DropColumn("dbo.Albums", "CoverImageId");
            DropTable("dbo.TrackPlaylists");
            DropTable("dbo.CoverImages");
            CreateIndex("dbo.Tracks", "Playlist_Id");
            AddForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists", "Id");
        }
    }
}
