using System.Data.Entity;

namespace BookCarProject.Models
{
    public partial class DbContextBookCar : DbContext
    {
        public DbContextBookCar()
            : base("name=DbContextBookCar")
        {
        }

        public virtual DbSet<BookCarDetail> BookCarDetails { get; set; }
        public virtual DbSet<BookCar> BookCars { get; set; }
        public virtual DbSet<CarCategory> CarCategories { get; set; }
        public virtual DbSet<CarProduct> CarProducts { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<GearBox> GearBoxs { get; set; }
        public virtual DbSet<UserCustomer> UserCustomers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCarDetail>()
                .Property(e => e.TotalRental)
                .HasPrecision(19, 1);

            modelBuilder.Entity<CarCategory>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.CarCategory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CarProduct>()
                .Property(e => e.RentCost)
                .HasPrecision(19, 1);

            modelBuilder.Entity<Fuel>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.Fuel)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GearBox>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.GearBox)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserCustomer>()
                .Property(e => e.CardIDUser)
                .IsUnicode(false);

            modelBuilder.Entity<UserCustomer>()
                .Property(e => e.NumberPhoneUser)
                .IsUnicode(false);

            modelBuilder.Entity<UserCustomer>()
                .HasMany(e => e.BookCars)
                .WithOptional(e => e.UserCustomer)
                .WillCascadeOnDelete();
        }
    }
}
