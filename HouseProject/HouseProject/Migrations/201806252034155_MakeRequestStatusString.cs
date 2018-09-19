namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRequestStatusString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostRequests", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostRequests", "RequestStatus", c => c.Int(nullable: false));
        }
    }
}
