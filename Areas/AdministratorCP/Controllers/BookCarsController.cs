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
    public class BookCarsController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: BookCars
        public ActionResult Index()
        {
            var bookCars = db.BookCars.Include(b => b.UserCustomer);
            return View(bookCars.ToList());
        }

        // GET: BookCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            return View(bookCar);
        }

        // GET: BookCars/Create
        public ActionResult Create()
        {
            ViewBag.UserCustomersId = new SelectList(db.UserCustomers, "UserCustomersId", "FullNameUser");
            return View();
        }

        // POST: BookCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCarsId,DateBookCar,UserCustomersId")] BookCar bookCar)
        {
            if (ModelState.IsValid)
            {
                db.BookCars.Add(bookCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserCustomersId = new SelectList(db.UserCustomers, "UserCustomersId", "FullNameUser", bookCar.UserCustomersId);
            return View(bookCar);
        }

        // GET: BookCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserCustomersId = new SelectList(db.UserCustomers, "UserCustomersId", "FullNameUser", bookCar.UserCustomersId);
            return View(bookCar);
        }

        // POST: BookCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCarsId,DateBookCar,UserCustomersId")] BookCar bookCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserCustomersId = new SelectList(db.UserCustomers, "UserCustomersId", "FullNameUser", bookCar.UserCustomersId);
            return View(bookCar);
        }

        // GET: BookCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCar bookCar = db.BookCars.Find(id);
            if (bookCar == null)
            {
                return HttpNotFound();
            }
            return View(bookCar);
        }

        // POST: BookCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCar bookCar = db.BookCars.Find(id);
            db.BookCars.Remove(bookCar);
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
