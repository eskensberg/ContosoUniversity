using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBooking.Models
{
    public class RoomBooking
    {
        [Key]
        public int BookingId { get; set; }

        public string FirstMidName { get; set; }

        public DateTime DateStamp { get; set; }

        public DateTime BookedFrom { get; set; }

        public DateTime BookedUntil { get; set; }

        public string EventDescription { get; set; }

        public virtual ICollection<BookingRecord> Enrollments { get; set; }
    }
}