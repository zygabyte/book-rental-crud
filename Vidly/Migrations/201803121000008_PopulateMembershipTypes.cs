namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO MembershipType (Id, SignUpFee, DurationInMonths, DiscountRate) values (1, 10, 1, 10)");
            //Sql("INSERT INTO MembershipType (Id, SignUpFee, DurationInMonths, DiscountRate) values (2, 20, 2, 20)");
            //Sql("INSERT INTO MembershipType (Id, SignUpFee, DurationInMonths, DiscountRate) values (3, 30, 6, 30)");
            //Sql("INSERT INTO MembershipType (Id, SignUpFee, DurationInMonths, DiscountRate) values (4, 40, 9, 40)");
        }
        
        public override void Down()
        {
        }
    }
}
