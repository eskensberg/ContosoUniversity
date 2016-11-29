using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityBooking.DAL;
using UniversityBooking.Models;

namespace UniversityBooking.Controllers
{
    public class LinqController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Linq
        public ActionResult Index()
        {
            IEnumerable<Room> RoomQuery = db.Rooms.Include(c => c.BookingRecords).Where(room => room.RoomId == 1);
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> EvenNumbers = Numbers.Where(n => n % 2 == 0);
            return View(RoomQuery.ToList());

            //return View(db.Rooms.ToList());
        }

        // GET: Linq/Details/5
        public ActionResult Chars(string inputString)
        {
            if (inputString.Length > 0)
            {
                char[] charArray = inputString.ToCharArray();
                charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);
                ViewBag.Array = charArray.ToList();
                return View(ViewBag.Array);
            }
            return View(inputString);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
