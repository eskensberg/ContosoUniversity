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

        [Display(Name = "UserID")]
        public int UserID { get; set; }

        //[Display(Name = "Number")]
        //public int RoomId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM}", ApplyFormatInEditMode = false)]
        [Display(Name = "Start Date")]
        public DateTime DateStamp { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM}", ApplyFormatInEditMode = false)]

        [Display(Name = "Start Date")]
        public DateTime BookedFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM}", ApplyFormatInEditMode = false)]
        [Display(Name = "Booked Until")]
        public DateTime BookedUntil { get; set; }

        [Display(Name = "Describe the event")]
        public string EventDescription { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}