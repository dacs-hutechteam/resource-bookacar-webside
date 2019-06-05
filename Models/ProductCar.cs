using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCarProject.Models
{
    public class ProductCar
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên xe")]
        public string modelCar { get; set; }

        [Required]
        [StringLength(30)]
        public string numberLicense { get; set; }

        [DisplayName("Số lượng ghế")]
        public string soGhe { get; set; }

        [StringLength(128)]
        public string image1 { get; set; }

        [StringLength(128)]
        public string image2 { get; set; }

        public string info { get; set; }

        [StringLength(100)]
        public string keyword { get; set; }

        public int soLuongTon { get; set; }

        [Required]
        public bool valid { get; set; }

        [Required]
        public double giaThue { get; set; }
    }
}