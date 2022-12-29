namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) values (1, 'Free', 0, 0, 0)");  //resharper: for copy: ctr+d 
            Sql("insert into MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) values (2, 'Silver', 1, 10, 5)");
            Sql("insert into MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) values (3, 'Boronz', 90, 3, 15)");
            Sql("insert into MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) values (4, 'Gold', 300, 12, 22)");
        }
        
        public override void Down()
        {
        }
    }
}
