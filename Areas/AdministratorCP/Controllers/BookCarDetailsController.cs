using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCarProject.Models;

namespace BookCarProject.Areas.AdministratorCP.Views.Home
{
    public class BookCarDetailsController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: BookCarDetails
        public ActionResult Index()
        {
            var bookCarDetails = db.BookCarDetails.Include(b => b.BookCar).Include(b => b.CarProduct);
            return View(bookCarDetails.ToList());
        }

        // GET: BookCarDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCarDetail bookCarDetail = db.BookCarDetails.Find(id);
            if (bookCarDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookCarDetail);
        }

        // GET: BookCarDetails/Create
        public ActionResult Create()
        {
            ViewBag.BookCarsId = new SelectList(db.BookCars, "BookCarsId", "BookCarsId");
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar");
            return View();
        }

        // POST: BookCarDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCarsId,CarProductsId,TotalRental,DateOfReceive,DateReturn,PaymentStatus")] BookCarDetail bookCarDetail)
        {
            if (ModelState.IsValid)
            {
                db.BookCarDetails.Add(bookCarDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookCarsId = new SelectList(db.BookCars, "BookCarsId", "BookCarsId", bookCarDetail.BookCarsId);
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCarDetail.CarProductsId);
            return View(bookCarDetail);
        }

        // GET: BookCarDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCarDetail bookCarDetail = db.BookCarDetails.Find(id);
            if (bookCarDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookCarsId = new SelectList(db.BookCars, "BookCarsId", "BookCarsId", bookCarDetail.BookCarsId);
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCarDetail.CarProductsId);
            return View(bookCarDetail);
        }

        // POST: BookCarDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCarsId,CarProductsId,TotalRental,DateOfReceive,DateReturn,PaymentStatus")] BookCarDetail bookCarDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCarDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookCarsId = new SelectList(db.BookCars, "BookCarsId", "BookCarsId", bookCarDetail.BookCarsId);
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar", bookCarDetail.CarProductsId);
            return View(bookCarDetail);
        }

        // GET: BookCarDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCarDetail bookCarDetail = db.BookCarDetails.Find(id);
            if (bookCarDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookCarDetail);
        }

        // POST: BookCarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCarDetail bookCarDetail = db.BookCarDetails.Find(id);
            db.BookCarDetails.Remove(bookCarDetail);
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
