namespace BookCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserCustomer()
        {
            BookCars = new HashSet<BookCar>();
        }

        [Key]
        public int UserCustomersId { get; set; }

        [Required]
        [StringLength(60)]
        public string FullNameUser { get; set; }

        [Required]
        [StringLength(20)]
        public string CardIDUser { get; set; }

        [Required]
        [StringLength(128)]
        public string AddressUser { get; set; }

        [Required]
        [StringLength(12)]
        public string NumberPhoneUser { get; set; }

        [Required]
        [StringLength(128)]
        public string EmailUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookCar> BookCars { get; set; }
    }
}
