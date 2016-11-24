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
   

        public virtual Room Room { get; set; } 
    }
}