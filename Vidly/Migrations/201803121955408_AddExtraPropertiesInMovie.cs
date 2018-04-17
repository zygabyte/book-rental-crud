namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtraPropertiesInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "DateAdded");
            DropColumn("dbo.Books", "ReleaseDate");
        }
    }
}
