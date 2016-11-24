namespace UniversityBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittoroomlocations3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoomLocations", "Credits");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomLocations", "Credits", c => c.Int(nullable: false));
        }
    }
}
