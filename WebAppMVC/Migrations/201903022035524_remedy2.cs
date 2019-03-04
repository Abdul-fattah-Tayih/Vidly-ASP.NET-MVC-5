namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remedy2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreId" });
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "genreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genreId");
            AddForeignKey("dbo.Movies", "genreId", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreId" });
            AlterColumn("dbo.Movies", "genreId", c => c.Int());
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime());
            CreateIndex("dbo.Movies", "genreId");
            AddForeignKey("dbo.Movies", "genreId", "dbo.Genres", "id");
        }
    }
}
