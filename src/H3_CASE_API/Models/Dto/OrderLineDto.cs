using H3_CASE_API.Models;

namespace H3_CASE_API.Models.Dto
{
    public class OrderLineDto
    {
        public Guid OrderLineID { get; set; }

        public int ProductID { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }

    }
}
