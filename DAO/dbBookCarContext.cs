using BookCarProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookCarProject.DAO
{
    public class dbBookCarContext : DbContext
    {
        public DbSet<CategoryCar> categoryCars { get; set; }
        /*public DbSet<ProductCar> productCars { get; set; }*/
        public dbBookCarContext() : base("name=BookCarProjectDatabase")
        {

        }
    }
}