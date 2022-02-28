using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public int? Contact_InformaitionID { get; set; }
        [ForeignKey("Contact_InformaitionID")]
        public Contact_Informaition? Contact_Informaition { get; set; }
    }
}
