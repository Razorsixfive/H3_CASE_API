using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Product_Status
    {
        [Key]
        public int Product_StatusID { get; set; }
        public string? Status_Name { get; set; }
    }
}
