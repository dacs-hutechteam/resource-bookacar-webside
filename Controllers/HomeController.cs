using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BookCarProject.Models;

namespace BookCarProject.Controllers
{
    public class HomeController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: Home
        public ActionResult Index()
        {
           
            return View(db.CarProducts);
        }
        public ActionResult Details(int? id)
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
        public ActionResult CourseCategories()
        {
            var courseCat = from cat in db.CarCategories select cat;
            return PartialView(courseCat);
        }
        public ActionResult TheLoaiSanPham(int id)
        {
            var products = from product in db.CarProducts where product.CarProductsId == id select product;
            return View(products);
        }
    }
}