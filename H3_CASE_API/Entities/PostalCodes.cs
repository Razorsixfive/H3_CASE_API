using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Models
{
    public class PostalCodes
    {
        [Key]
        public int PostalCode { get; set; }

        public string? City { get; set; }
    }
}
