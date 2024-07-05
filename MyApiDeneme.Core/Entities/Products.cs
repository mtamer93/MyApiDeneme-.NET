using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.Core.Entities
{
    public class Products
    {
        [Key]
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Required]
        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int? SupplierID { get; set; }

        [Column("CategoryID")]
        public int? CategoryID { get; set; }

        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }

        [Column("UnitsInStock")]
        public short? UnitsInStock { get; set; }

        [Column("UnitsOnOrder")]
        public short? UnitsOnOrder { get; set; }

        [Column("ReorderLevel")]
        public short? ReorderLevel { get; set; }

        [Required]
        [Column("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
