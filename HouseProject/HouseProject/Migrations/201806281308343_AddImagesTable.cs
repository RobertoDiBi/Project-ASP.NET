namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseImage = c.Byte(nullable: false),
                        Home_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Homes", t => t.Home_ID)
                .Index(t => t.Home_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Home_ID", "dbo.Homes");
            DropIndex("dbo.Images", new[] { "Home_ID" });
            DropTable("dbo.Images");
        }
    }
}
