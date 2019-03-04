namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remedy : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "genre_id", newName: "genreId");
            RenameIndex(table: "dbo.Movies", name: "IX_genre_id", newName: "IX_genreId");
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime());
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.Movies", name: "IX_genreId", newName: "IX_genre_id");
            RenameColumn(table: "dbo.Movies", name: "genreId", newName: "genre_id");
        }
    }
}
