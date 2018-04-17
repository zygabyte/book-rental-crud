namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmovies : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Books");
        }

        public override void Down()
        {
        }
    }
}
