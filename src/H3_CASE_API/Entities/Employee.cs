using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department? Department { get; set; }

        public int Contact_InformaitionID { get; set; }
        [ForeignKey("Contact_InformaitionID")]

        public Contact_Informaition? Contact_Informaition { get; set; }
    }
}
