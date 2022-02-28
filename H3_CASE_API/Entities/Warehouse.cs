using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using H3_CASE_API.Dto;

namespace H3_CASE_API.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]

        public Department? Department { get; set; }

        public int Contact_InformaitionID { get; set; }
        [ForeignKey("Contact_InformaitionID")]

        public Contact_Informaition? Contact_Informaition { get; set; }

        public virtual ICollection<Product_Stock>? Product_Stocks { get; set; }
    }
}
