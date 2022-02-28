using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Models
{
    public class Delivery_Service
    {
        [Key]
        public int Delivery_ServiceID { get; set; }
        public string? Courier_Name { get; set; }
    }
}
