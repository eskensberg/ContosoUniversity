using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBooking.Models
{
    public class RoomLocations
    {
        [Key]
        public int RoomId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<BookingRecord> BookingRecords { get; set; }
    }
}