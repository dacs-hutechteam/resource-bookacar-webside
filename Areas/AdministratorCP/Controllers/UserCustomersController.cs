using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCarProject.Models;

namespace BookCarProject.Areas.AdministratorCP.Controllers
{
    public class UserCustomersController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: UserCustomers
        public ActionResult Index()
        {
            return View(db.UserCustomers.ToList());
        }

        // GET: UserCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomer userCustomer = db.UserCustomers.Find(id);
            if (userCustomer == null)
            {
                return HttpNotFound();
            }
            return View(userCustomer);
        }

        // GET: UserCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserCustomersId,FullNameUser,CardIDUser,AddressUser,NumberPhoneUser,EmailUser")] UserCustomer userCustomer)
        {
            if (ModelState.IsValid)
            {
                db.UserCustomers.Add(userCustomer);
                db.SaveChanges();
                return RedirectToAction("Create","BookCars");
            }

            return View(userCustomer);
        }

        // GET: UserCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomer userCustomer = db.UserCustomers.Find(id);
            if (userCustomer == null)
            {
                return HttpNotFound();
            }
            return View(userCustomer);
        }

        // POST: UserCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserCustomersId,FullNameUser,CardIDUser,AddressUser,NumberPhoneUser,EmailUser")] UserCustomer userCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCustomer);
        }

        // GET: UserCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCustomer userCustomer = db.UserCustomers.Find(id);
            if (userCustomer == null)
            {
                return HttpNotFound();
            }
            return View(userCustomer);
        }

        // POST: UserCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCustomer userCustomer = db.UserCustomers.Find(id);
            db.UserCustomers.Remove(userCustomer);
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
