using H3_CASE_API.Models;

namespace H3_CASE_API.Dto
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public Category? Category { get; set; }
        public Manufactor? Manufactor { get; set; }
        public string? Product_Description { get; set; }
        public string? Product_Name { get; set; }
        public double In_Price { get; set; }
        public double Out_Price { get; set; }

    }
}
