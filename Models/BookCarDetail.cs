namespace BookCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookCarDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookCarsId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarProductsId { get; set; }

        public decimal TotalRental { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfReceive { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateReturn { get; set; }

        public bool? PaymentStatus { get; set; }

        public virtual BookCar BookCar { get; set; }

        public virtual CarProduct CarProduct { get; set; }
    }
}
