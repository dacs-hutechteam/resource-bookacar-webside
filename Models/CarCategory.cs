namespace BookCarProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarCategory()
        {
            CarProducts = new HashSet<CarProduct>();
        }

        public int CarCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("H�ng xe")]
        public string NameCarCategory { get; set; }

        [DisplayName("C�n kinh doanh")]
        public bool CarCategoryStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarProduct> CarProducts { get; set; }
    }
}
