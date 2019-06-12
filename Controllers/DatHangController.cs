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
        public ActionResult DatHangXe()
        { 
            ViewBag.BookCarsId = new SelectList(db.BookCars, "BookCarsId", "BookCarsId");
            ViewBag.CarProductsId = new SelectList(db.CarProducts, "CarProductsId", "ModelCar");
            ViewBag.UserCustomersId = new SelectList(db.UserCustomers, "UserCustomersId", "FullNameUser");
            return View();
        }
    }
}