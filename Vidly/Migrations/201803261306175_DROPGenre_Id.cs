namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DROPGenre_Id : DbMigration
    {
        public override void Up()
        {
//            Sql("ALTER TABLE dbo.Books DROP CONSTRAINT IX_Genre_Id; ");
            Sql("ALTER TABLE dbo.Books DROP COLUMN Genre_Id; ");
        }
        
        public override void Down()
        {
        }
    }
}
