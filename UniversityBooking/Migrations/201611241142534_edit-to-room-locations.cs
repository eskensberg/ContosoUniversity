namespace UniversityBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittoroomlocations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomLocations", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomLocations", "Credits");
        }
    }
}
