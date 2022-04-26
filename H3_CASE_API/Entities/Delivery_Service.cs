using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Entities
{
    public class Delivery_Service
    {
        [Key]
        public int Delivery_ServiceID { get; set; }
        public string? Courier_Name { get; set; }
    }
}
