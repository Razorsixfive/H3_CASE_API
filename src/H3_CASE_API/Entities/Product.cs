using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public int ManufactorID { get; set; }
        [ForeignKey("ManufactorID")]
        public Manufactor? Manufactor { get; set; }
        public int Product_StatusID { get; set; }
        [ForeignKey("Product_StatusID")]
        public Product_Status? Product_Status { get; set; }

        public string? Product_Description { get; set; }
        public string? Product_Name { get; set; }
        public double In_Price { get; set; }
        public double Out_Price { get; set; }
    }
}
