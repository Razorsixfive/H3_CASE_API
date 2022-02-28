using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Contact_Informaition
    {
        [Key]
        public int Contact_InformaitionID { get; set; }

        public int Contact_TypeID { get; set; }
        [ForeignKey("Contact_TypeID")]
        public Contact_Type? Contact_Type { get; set; }

        [ForeignKey("Contact_InformaitionID")]
        public virtual ICollection<Addrese>? Addrese { get; set; }

        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Phone_Number { get; set; }
        public string? Mobile_Number { get; set; }
    }
}
