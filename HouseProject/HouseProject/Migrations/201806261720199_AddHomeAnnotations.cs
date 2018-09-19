namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homes", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Homes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Homes", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Homes", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Homes", "Province", c => c.String(nullable: false));
            AlterColumn("dbo.Homes", "PostalCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homes", "PostalCode", c => c.String());
            AlterColumn("dbo.Homes", "Province", c => c.String());
            AlterColumn("dbo.Homes", "City", c => c.String());
            AlterColumn("dbo.Homes", "Address", c => c.String());
            AlterColumn("dbo.Homes", "Title", c => c.String());
            AlterColumn("dbo.Homes", "Description", c => c.String());
        }
    }
}
