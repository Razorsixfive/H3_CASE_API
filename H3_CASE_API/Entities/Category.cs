using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3_CASE_API.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? Category_Name { get; set; }
        //public ICollection<Product> Products { get; set; }
    }
}
