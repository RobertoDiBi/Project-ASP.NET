namespace HouseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAmenities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Amenities (Name) VALUES ('Television')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Satellite')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Wi-Fi')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Pool')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Spa')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Sauna')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Washer')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Dryer')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Fireplace')");
            Sql("INSERT INTO Amenities (Name) VALUES ('Firewood')");
        }
        
        public override void Down()
        {
        }
    }
}
