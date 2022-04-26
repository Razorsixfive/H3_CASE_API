using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Entities
{
    public class Orders
    {
        [Key]
        public int OrdersID { get; set; }

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        public int Delivery_ServiceID { get; set; }
        public Delivery_Service? Delivery_Service { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }

        public DateTime Payment_Date { get; set; }
        public DateTime Shipment_Date { get; set; }
        public DateTime Delivery_Date { get; set; }

        public Orders(){ }
        public Orders(InputDataModels.Put_Order Order){ 
            this.Delivery_ServiceID = Order.Delivery_ServiceID;
            this.CustomerID = Order.CustomerID;
            this.EmployeeID = Order.EmployeeID;

            this.Payment_Date = DateTime.UtcNow;
            this.Shipment_Date = DateTime.UtcNow;
            this.Delivery_Date = DateTime.UtcNow;
        }
    }
}
