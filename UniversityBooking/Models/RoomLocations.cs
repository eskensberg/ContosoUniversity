using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityBooking.Models
{
    public class RoomLocations
    {
        //[ForeignKey("Room")]
        [Key]
        public int LocationId { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }
   
        public virtual ICollection<Room> Rooms { get; set; }


    }
}