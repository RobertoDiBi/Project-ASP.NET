namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHostRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                        HomeTypeID = c.Int(nullable: false),
                        NumOfRooms = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        MaxOccupants = c.Int(nullable: false),
                        PricePerNight = c.Double(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HomeTypes", t => t.HomeTypeID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.HomeTypeID)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.BookingRecords", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Amenities", "HostRequest_ID", c => c.Int());
            CreateIndex("dbo.BookingRecords", "User_Id");
            CreateIndex("dbo.Amenities", "HostRequest_ID");
            AddForeignKey("dbo.BookingRecords", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Amenities", "HostRequest_ID", "dbo.HostRequests", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostRequests", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.HostRequests", "HomeTypeID", "dbo.HomeTypes");
            DropForeignKey("dbo.Amenities", "HostRequest_ID", "dbo.HostRequests");
            DropForeignKey("dbo.BookingRecords", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HostRequests", new[] { "User_Id" });
            DropIndex("dbo.HostRequests", new[] { "HomeTypeID" });
            DropIndex("dbo.Amenities", new[] { "HostRequest_ID" });
            DropIndex("dbo.BookingRecords", new[] { "User_Id" });
            DropColumn("dbo.Amenities", "HostRequest_ID");
            DropColumn("dbo.BookingRecords", "User_Id");
            DropTable("dbo.HostRequests");
        }
    }
}
