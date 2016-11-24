﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UniversityBooking.Models;

namespace UniversityBooking.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<BookingRecord> BookingRecords { get; set; }
        public DbSet<RoomLocations> RoomLocations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; } 
        public DbSet<Instructor> Instructors { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; } 

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Instructors).WithMany(i => i.Courses)
        //        .Map(t => t.MapLeftKey("CourseID")
        //            .MapRightKey("InstructorID")
        //            .ToTable("CourseInstructor"));
        //    modelBuilder.Entity<Department>().MapToStoredProcedures();

        //    modelBuilder.Entity<BookingRecord>()
        //        .HasMany(c => c.Rooms).WithMany(i => i.BookingRecords);
              
        //    modelBuilder.Entity<Department>().MapToStoredProcedures();
        //}
    }
}