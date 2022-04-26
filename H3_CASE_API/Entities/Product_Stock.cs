using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Entities
{
    public class Product_Stock
    {
        [Key]
        public int Product_StockID { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]

        public Product Product { get; set; }

        public int WarehouseID { get; set; }
        [ForeignKey("WarehouseID")]

        public Warehouse Warehouse { get; set; }

        public int Ammount { get; set; }
    }
}
