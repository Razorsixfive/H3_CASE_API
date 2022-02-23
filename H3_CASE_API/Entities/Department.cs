using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public int Contact_InformaitionID { get; set; }
        [ForeignKey("Contact_InformaitionID")]

        public Contact_Informaition? Contact_Informaition { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
