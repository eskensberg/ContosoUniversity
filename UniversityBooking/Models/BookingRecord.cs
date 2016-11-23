using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityBooking.Models
{

    public class BookingRecord
    {
        [Key]
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }

        public virtual RoomBooking RoomBooking { get; set; }
        public virtual RoomLocations RoomLocations { get; set; }
    }
}