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
        //Has TV? HDMI?
        //List of games 
        // Couches?
        // 1 to many relationship with things in the room

        public virtual ICollection<BookingRecord> BookingRecords { get; set; }
    }
}