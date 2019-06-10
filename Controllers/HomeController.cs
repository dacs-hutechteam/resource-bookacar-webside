using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BookCarProject.Models;

namespace BookCarProject.Controllers
{
    public class HomeController : Controller
    {
        private DbContextBookCar db = new DbContextBookCar();

        // GET: Home
        public ActionResult Index(string SearchString, int? cateId, int? Page_No, int Size_Of_Page = 6)
        {
            //int number_Of_Page = Page_No ?? 1;
            //var products = db.Products.Include(p => p.category).OrderBy(p => p.id).ToPagedList(number_Of_Page, Size_Of_Page);
            var products = db.CarProducts.Include(p => p.CarCategory).Where(p => p.ModelCar.Contains(SearchString) || SearchString == null).OrderBy(p => p.CarProductsId).ToPagedList(Page_No ?? 1, Size_Of_Page);
            return View(db.CarProducts);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            CarProduct product = db.CarProducts.Include(p => p.CarCategory).Where(p => p.CarCategoryId == id).FirstOrDefault();
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