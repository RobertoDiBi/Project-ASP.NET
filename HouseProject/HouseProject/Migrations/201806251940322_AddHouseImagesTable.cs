namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHouseImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        HomeID = c.Int(nullable: false),
                        IsMainImage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Homes", t => t.HomeID, cascadeDelete: true)
                .Index(t => t.HomeID);
            
            AddColumn("dbo.HostRequests", "RequestDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseImages", "HomeID", "dbo.Homes");
            DropIndex("dbo.HouseImages", new[] { "HomeID" });
            DropColumn("dbo.HostRequests", "RequestDate");
            DropTable("dbo.HouseImages");
        }
    }
}
