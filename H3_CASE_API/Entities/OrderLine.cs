using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Models
{
    public class OrderLine
    {
        [Key]
        public Guid OrderLineID { get; set; }

        public int OrdersID { get; set; }
        public Orders? Orders { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public int Ammount { get; set; }
        public double Price { get; set; }
    }
}
