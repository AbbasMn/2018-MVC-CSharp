namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationDataAnnotationToCustomer2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Family", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Family", c => c.String(maxLength: 200));
        }
    }
}
