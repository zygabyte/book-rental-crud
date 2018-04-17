namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedGenre_Id : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Books DROP COLUMN Genre_Id; ");
        }
        
        public override void Down()
        {
        }
    }
}
