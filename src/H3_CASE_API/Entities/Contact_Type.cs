using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Models
{
    public class Contact_Type
    {
        [Key]
        public int Contact_TypeID { get; set; }
        public string? ContactType { get; set; }
    }
}
