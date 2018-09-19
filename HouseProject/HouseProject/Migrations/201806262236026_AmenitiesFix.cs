namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmenitiesFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Amenities", new[] { "Home_ID" });
            CreateTable(
                "dbo.SelectedAmenities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Home_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Home_ID);

            DropForeignKey("dbo.Amenities", "FK_dbo.Amenities_dbo.Homes_Home_ID");
            DropColumn("dbo.Amenities", "Home_ID");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Amenities", "Home_ID", c => c.Int());
            DropIndex("dbo.SelectedAmenities", new[] { "Home_ID" });
            DropTable("dbo.SelectedAmenities");
            CreateIndex("dbo.Amenities", "Home_ID");
        }
    }
}
