namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedImagesType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "HouseImage", c => c.Binary(maxLength: 8000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "HouseImage", c => c.Byte(nullable: false));
        }
    }
}
