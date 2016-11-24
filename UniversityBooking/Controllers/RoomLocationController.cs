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
    public class RoomLocationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: RoomLocation
        public ActionResult Index()
        {
            return View(db.RoomLocation.ToList());
        }

        // GET: RoomLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomLocations roomLocations = db.RoomLocation.Find(id);
            if (roomLocations == null)
            {
                return HttpNotFound();
            }
            return View(roomLocations);
        }

        // GET: RoomLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomId,Title")] RoomLocations roomLocations)
        {
            if (ModelState.IsValid)
            {
                db.RoomLocation.Add(roomLocations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomLocations);
        }

        // GET: RoomLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomLocations roomLocations = db.RoomLocation.Find(id);
            if (roomLocations == null)
            {
                return HttpNotFound();
            }
            return View(roomLocations);
        }

        // POST: RoomLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomId,Title")] RoomLocations roomLocations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomLocations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomLocations);
        }

        // GET: RoomLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomLocations roomLocations = db.RoomLocation.Find(id);
            if (roomLocations == null)
            {
                return HttpNotFound();
            }
            return View(roomLocations);
        }

        // POST: RoomLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomLocations roomLocations = db.RoomLocation.Find(id);
            db.RoomLocation.Remove(roomLocations);
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
