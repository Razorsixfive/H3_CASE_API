using H3_CASE_API.Entities;
using H3_CASE_API.Entities;

namespace H3_CASE_API.Entities.Dto
{
    public class OrdersDto
    {
        public int OrdersID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int Delivery_ServiceID { get; set; }

        public double TotalPrice { get; set; }
        public int OrderlinesCount { get; set; }

        public DateTime? Payment_Date { get; set; }
        public DateTime? Shipment_Date { get; set; }
        public DateTime? Delivery_Date { get; set; }

        public ICollection<OrderLineDto>? OrderLines { get; set; }
        public virtual IEnumerable<Link> Links { get; set; }
    }
}
