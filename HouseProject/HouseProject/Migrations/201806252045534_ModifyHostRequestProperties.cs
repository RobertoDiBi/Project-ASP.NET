namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyHostRequestProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Amenities", "HostRequest_ID", "dbo.HostRequests");
            DropForeignKey("dbo.HostRequests", "HomeTypeID", "dbo.HomeTypes");
            DropIndex("dbo.Amenities", new[] { "HostRequest_ID" });
            DropIndex("dbo.HostRequests", new[] { "HomeTypeID" });
            AddColumn("dbo.Homes", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.HostRequests", "HomeID", c => c.Int(nullable: false));
            CreateIndex("dbo.HostRequests", "HomeID");
            AddForeignKey("dbo.HostRequests", "HomeID", "dbo.Homes", "ID", cascadeDelete: true);
            DropColumn("dbo.Amenities", "HostRequest_ID");
            DropColumn("dbo.HostRequests", "Description");
            DropColumn("dbo.HostRequests", "Title");
            DropColumn("dbo.HostRequests", "HomeTypeID");
            DropColumn("dbo.HostRequests", "NumOfRooms");
            DropColumn("dbo.HostRequests", "Address");
            DropColumn("dbo.HostRequests", "City");
            DropColumn("dbo.HostRequests", "Province");
            DropColumn("dbo.HostRequests", "PostalCode");
            DropColumn("dbo.HostRequests", "MaxOccupants");
            DropColumn("dbo.HostRequests", "PricePerNight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HostRequests", "PricePerNight", c => c.Double(nullable: false));
            AddColumn("dbo.HostRequests", "MaxOccupants", c => c.Int(nullable: false));
            AddColumn("dbo.HostRequests", "PostalCode", c => c.String());
            AddColumn("dbo.HostRequests", "Province", c => c.String());
            AddColumn("dbo.HostRequests", "City", c => c.String());
            AddColumn("dbo.HostRequests", "Address", c => c.String());
            AddColumn("dbo.HostRequests", "NumOfRooms", c => c.Int(nullable: false));
            AddColumn("dbo.HostRequests", "HomeTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.HostRequests", "Title", c => c.String());
            AddColumn("dbo.HostRequests", "Description", c => c.String());
            AddColumn("dbo.Amenities", "HostRequest_ID", c => c.Int());
            DropForeignKey("dbo.HostRequests", "HomeID", "dbo.Homes");
            DropIndex("dbo.HostRequests", new[] { "HomeID" });
            DropColumn("dbo.HostRequests", "HomeID");
            DropColumn("dbo.Homes", "Approved");
            CreateIndex("dbo.HostRequests", "HomeTypeID");
            CreateIndex("dbo.Amenities", "HostRequest_ID");
            AddForeignKey("dbo.HostRequests", "HomeTypeID", "dbo.HomeTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Amenities", "HostRequest_ID", "dbo.HostRequests", "ID");
        }
    }
}
