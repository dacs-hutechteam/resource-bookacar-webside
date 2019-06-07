﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCarProject.Models;

namespace BookCarProject.Controllers
{
    public class CarProductsController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: CarProducts
        public ActionResult Index()
        {
            var carProducts = db.CarProducts.Include(c => c.CarCategory).Include(c => c.Fuel).Include(c => c.GearBox);
            return View(carProducts.ToList());
        }

        // GET: CarProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarProduct carProduct = db.CarProducts.Find(id);
            if (carProduct == null)
            {
                return HttpNotFound();
            }
            return View(carProduct);
        }

        // GET: CarProducts/Create
        public ActionResult Create()
        {
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory");
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel");
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox");
            return View();
        }

        // POST: CarProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarProductsId,ModelCar,CarColor,NumberOfSeats,ImageFont,ImageBack,Keyword,NumberOfCars,ActionProduct,RentCost,CarProductStatus,CarCategoryId,FuelsId,GearBoxsId")] CarProduct carProduct)
        {
            if (ModelState.IsValid)
            {
                db.CarProducts.Add(carProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory", carProduct.CarCategoryId);
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel", carProduct.FuelsId);
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox", carProduct.GearBoxsId);
            return View(carProduct);
        }

        // GET: CarProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarProduct carProduct = db.CarProducts.Find(id);
            if (carProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory", carProduct.CarCategoryId);
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel", carProduct.FuelsId);
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox", carProduct.GearBoxsId);
            return View(carProduct);
        }

        // POST: CarProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarProductsId,ModelCar,CarColor,NumberOfSeats,ImageFont,ImageBack,Keyword,NumberOfCars,ActionProduct,RentCost,CarProductStatus,CarCategoryId,FuelsId,GearBoxsId")] CarProduct carProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carProduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory", carProduct.CarCategoryId);
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel", carProduct.FuelsId);
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox", carProduct.GearBoxsId);
            return View(carProduct);
        }

        // GET: CarProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarProduct carProduct = db.CarProducts.Find(id);
            if (carProduct == null)
            {
                return HttpNotFound();
            }
            return View(carProduct);
        }

        // POST: CarProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarProduct carProduct = db.CarProducts.Find(id);
            db.CarProducts.Remove(carProduct);
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
