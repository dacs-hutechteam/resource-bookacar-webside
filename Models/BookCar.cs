namespace BookCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookCar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookCar()
        {
            BookCarDetails = new HashSet<BookCarDetail>();
        }

        [Key]
        public int BookCarsId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateBookCar { get; set; }

        public int? UserCustomersId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookCarDetail> BookCarDetails { get; set; }

        public virtual UserCustomer UserCustomer { get; set; }
    }
}
