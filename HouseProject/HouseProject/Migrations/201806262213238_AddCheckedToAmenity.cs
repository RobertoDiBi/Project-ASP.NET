namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckedToAmenity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Amenities", "Checked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Amenities", "Checked");
        }
    }
}
