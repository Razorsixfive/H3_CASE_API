using H3_CASE_API.Models;
using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Dto
{
    public class Product_StockDto
    {
        public int ProductID { get; set; }
        public string? Product_Name { get; set; }
        public int Ammount { get; set; }

    }
}
