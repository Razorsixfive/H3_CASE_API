using System.ComponentModel.DataAnnotations;

namespace H3_CASE_API.Models
{
    public class Manufactor
    {
        [Key]
        public int ManufactorID { get; set; }

        public string? Manufactor_Name { get; set; }
    }
}
