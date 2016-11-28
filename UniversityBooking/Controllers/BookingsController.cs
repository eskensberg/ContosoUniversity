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
    public class BookingsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.BookingRecords.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRecord bookingRecord = db.BookingRecords.Find(id);
            if (bookingRecord == null)
            {
                return HttpNotFound();
            }
            return View(bookingRecord);
        }
        // example of => [Bind(Include = "DepartmentID,Name,Budget,StartDate,InstructorID")] Department department)
        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,UserID,DateStamp,BookedFrom,BookedUntil,EventDescription")] BookingRecord bookingRecord)
        {
            if (ModelState.IsValid)
            {
                //bookingRecord.DateStamp = DateTime.Parse.
                db.BookingRecords.Add(bookingRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingRecord);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRecord bookingRecord = db.BookingRecords.Find(id);
            if (bookingRecord == null)
            {
                return HttpNotFound();
            }
            return View(bookingRecord);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,UserID,DateStamp,BookedFrom,BookedUntil,EventDescription")] BookingRecord bookingRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingRecord);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRecord bookingRecord = db.BookingRecords.Find(id);
            if (bookingRecord == null)
            {
                return HttpNotFound();
            }
            return View(bookingRecord);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingRecord bookingRecord = db.BookingRecords.Find(id);
            db.BookingRecords.Remove(bookingRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
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
