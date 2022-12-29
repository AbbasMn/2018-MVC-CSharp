namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationDataAnnotationToCustomer1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Family", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Family", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
