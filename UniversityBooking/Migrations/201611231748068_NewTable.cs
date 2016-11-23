namespace UniversityBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingRecord",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        UserId = c.String(),
                        RoomBooking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.RoomBooking", t => t.RoomBooking_BookingId)
                .ForeignKey("dbo.RoomLocations", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.RoomBooking_BookingId);
            
            CreateTable(
                "dbo.RoomBooking",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        FirstMidName = c.String(),
                        DateStamp = c.DateTime(nullable: false),
                        BookedFrom = c.DateTime(nullable: false),
                        BookedUntil = c.DateTime(nullable: false),
                        EventDescription = c.String(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.RoomLocations",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingRecord", "RoomId", "dbo.RoomLocations");
            DropForeignKey("dbo.BookingRecord", "RoomBooking_BookingId", "dbo.RoomBooking");
            DropIndex("dbo.BookingRecord", new[] { "RoomBooking_BookingId" });
            DropIndex("dbo.BookingRecord", new[] { "RoomId" });
            DropTable("dbo.RoomLocations");
            DropTable("dbo.RoomBooking");
            DropTable("dbo.BookingRecord");
        }
    }
}
