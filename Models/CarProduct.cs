namespace BookCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarProduct()
        {
            BookCarDetails = new HashSet<BookCarDetail>();
        }

        [Key]
        public int CarProductsId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Model xe")]
        public string ModelCar { get; set; }

        [StringLength(20)]
        [DisplayName("Màu sắc")]
        public string CarColor { get; set; }

        [DisplayName("Số ghế ngồi")]
        public int? NumberOfSeats { get; set; }

        [StringLength(128)]
        public string ImageFont { get; set; }

        [StringLength(128)]
        public string ImageBack { get; set; }

        [StringLength(50)]
        public string Keyword { get; set; }

        [DisplayName("Số lượng xe")]
        public int NumberOfCars { get; set; }

        public bool? ActionProduct { get; set; }

        [DisplayName("Chi phí thuê xe")]
        public decimal RentCost { get; set; }

        [DisplayName("Còn hoạt động")]
        public bool CarProductStatus { get; set; }

        public int? CarCategoryId { get; set; }

        public int? FuelsId { get; set; }

        public int? GearBoxsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookCarDetail> BookCarDetails { get; set; }

        public virtual CarCategory CarCategory { get; set; }

        public virtual Fuel Fuel { get; set; }

        public virtual GearBox GearBox { get; set; }
    }
}
