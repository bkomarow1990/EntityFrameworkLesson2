namespace EntityFrameworkLesson2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Tracks", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Tracks", "Count_Listening", c => c.Int(nullable: false));
            AddColumn("dbo.Tracks", "Text", c => c.String());
            AlterColumn("dbo.Tracks", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Name", c => c.String());
            DropColumn("dbo.Tracks", "Text");
            DropColumn("dbo.Tracks", "Count_Listening");
            DropColumn("dbo.Tracks", "Rating");
            DropColumn("dbo.Albums", "Rating");
        }
    }
}
