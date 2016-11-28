using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityBooking.Models;

namespace UniversityBooking.ViewModels
{
    public class RoomBookingData
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<BookingRecord> BookingRecords { get; set; }
    }
}