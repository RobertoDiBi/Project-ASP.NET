namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleHostRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostRequests", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostRequests", "Title");
        }
    }
}
