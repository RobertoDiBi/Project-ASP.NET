namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitletoHomeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homes", "Title");
        }
    }
}
