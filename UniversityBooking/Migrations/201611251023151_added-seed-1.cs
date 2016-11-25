namespace UniversityBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseed1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingRecords",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DateStamp = c.DateTime(nullable: false),
                        BookedFrom = c.DateTime(nullable: false),
                        BookedUntil = c.DateTime(nullable: false),
                        EventDescription = c.String(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        RoomLocation_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.RoomLocations", t => t.RoomLocation_LocationId)
                .Index(t => t.RoomLocation_LocationId);
            
            CreateTable(
                "dbo.RoomLocations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        OfficeLocation = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomBookingRecords",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        BookingRecord_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.BookingRecord_BookingId })
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .ForeignKey("dbo.BookingRecords", t => t.BookingRecord_BookingId, cascadeDelete: true)
                .Index(t => t.Room_RoomId)
                .Index(t => t.BookingRecord_BookingId);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_ID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_ID, t.Course_CourseID })
                .ForeignKey("dbo.Instructors", t => t.Instructor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Instructor_ID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.OfficeAssignments", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_ID", "dbo.Instructors");
            DropForeignKey("dbo.Rooms", "RoomLocation_LocationId", "dbo.RoomLocations");
            DropForeignKey("dbo.RoomBookingRecords", "BookingRecord_BookingId", "dbo.BookingRecords");
            DropForeignKey("dbo.RoomBookingRecords", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.InstructorCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_ID" });
            DropIndex("dbo.RoomBookingRecords", new[] { "BookingRecord_BookingId" });
            DropIndex("dbo.RoomBookingRecords", new[] { "Room_RoomId" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorID" });
            DropIndex("dbo.Departments", new[] { "InstructorID" });
            DropIndex("dbo.Courses", new[] { "DepartmentID" });
            DropIndex("dbo.Rooms", new[] { "RoomLocation_LocationId" });
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.RoomBookingRecords");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.RoomLocations");
            DropTable("dbo.Rooms");
            DropTable("dbo.BookingRecords");
        }
    }
}
