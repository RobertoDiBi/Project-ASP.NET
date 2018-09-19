namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Birthdate]) VALUES (N'fe8caa24-138b-4039-abf9-6809d810a08e', N'brandon@admin.com', 0, N'AKoj1zPbDdEawG38vylLF4M3QDh5l74I+EIgB/kgmhF24LQdJ8BGfLt6/Ph4Ubbmhw==', N'2aa96ac6-b4af-403c-8f6d-3d92990e80a0', NULL, 0, 0, NULL, 1, 0, N'brandon@admin.com', N'Brandon', N'Lauer', N'1998-08-07 00:00:00')");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e4c59778-f525-4b63-80ac-3555eb476ceb', N'Admin')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe8caa24-138b-4039-abf9-6809d810a08e', N'e4c59778-f525-4b63-80ac-3555eb476ceb')");
        }
        
        public override void Down()
        {
        }
    }
}
