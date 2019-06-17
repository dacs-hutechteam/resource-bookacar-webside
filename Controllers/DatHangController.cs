using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCarProject.Models;

namespace BookCarProject.Controllers
{
    public class DatHangController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();
        // GET: DatHang
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult DatHangXe(int? id)
        {
            ViewBag.CarCategoryId = new SelectList(db.CarCategories, "CarCategoryId", "NameCarCategory");
            ViewBag.FuelsId = new SelectList(db.Fuels, "FuelsId", "NameFuel");
            ViewBag.GearBoxsId = new SelectList(db.GearBoxs, "GearBoxsId", "NameGearBox");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            CarProduct product = db.CarProducts.Include(p => p.CarCategory).Where(p => p.CarProductsId == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}