using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityBooking.Models;

namespace UniversityBooking.Controllers
{
    [Authorize]
    public class DepositController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Deposit
        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
            }
            return View();

        }
    }
}