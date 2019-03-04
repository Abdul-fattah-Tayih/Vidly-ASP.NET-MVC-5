namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (name) VALUES ('Action')");
            Sql("INSERT INTO Genres (name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (name) VALUES ('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
