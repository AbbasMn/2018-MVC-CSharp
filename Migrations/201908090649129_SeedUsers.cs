namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            // used for insert Users
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], 
                              [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
                              [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                              VALUES (N'599f303b-2796-42d2-8c8c-9a9b2aa0b9d3', N'Guest@gmail.com', 0, N'APMk8Eh70vURTw1lXWPYDukH/4h8HRjy7H+PmkVfzoouMAc0KRKXMuCbThF55rLTiA==', 
                              N'da8d0189-14cc-4d56-93d2-a73dfe1b99a6', NULL, 0, 0, NULL, 1, 0, N'Guest@gmail.com')
                  
                              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], 
                              [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
                              [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                              VALUES (N'743e4832-29cd-47fb-a66f-1489c10cfac2', N'admin@gmail.com', 0, N'AJirTc93/oFyhrSzNK/0CDvr4KIyqwhg1S7yI6NkbEeLzCX89+bZ0EsSXXtBzm/uNA==', 
                              N'a792840b-e43b-4d0f-8d23-e45955b684f1', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')"
               );


            // used for insert Roles
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ea99f342-108c-41d7-886b-e060dc5b0a86', N'CanManageEntertainments')");


            // used for insert userRoles
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'743e4832-29cd-47fb-a66f-1489c10cfac2', N'ea99f342-108c-41d7-886b-e060dc5b0a86')");
        }
        
        public override void Down()
        {
        }
    }
}
