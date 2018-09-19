namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeUserIDString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookingRecords", new[] { "User_Id" });
            DropIndex("dbo.HostRequests", new[] { "User_Id" });
            DropColumn("dbo.BookingRecords", "UserID");
            DropColumn("dbo.HostRequests", "UserID");
            RenameColumn(table: "dbo.BookingRecords", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.HostRequests", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.BookingRecords", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.HostRequests", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.BookingRecords", "UserID");
            CreateIndex("dbo.HostRequests", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HostRequests", new[] { "UserID" });
            DropIndex("dbo.BookingRecords", new[] { "UserID" });
            AlterColumn("dbo.HostRequests", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingRecords", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.HostRequests", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.BookingRecords", name: "UserID", newName: "User_Id");
            AddColumn("dbo.HostRequests", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.BookingRecords", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.HostRequests", "User_Id");
            CreateIndex("dbo.BookingRecords", "User_Id");
        }
    }
}
