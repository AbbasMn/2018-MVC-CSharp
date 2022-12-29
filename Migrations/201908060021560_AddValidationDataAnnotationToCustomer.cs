namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationDataAnnotationToCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "Family", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Family", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
