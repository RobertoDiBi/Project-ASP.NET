namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Homes", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Homes", "Title", c => c.String());
        }
    }
}
