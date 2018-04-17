namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Horror')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
