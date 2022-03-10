using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;

namespace H3_CASE_API.Models.Views
{
    public class ProductsView
    {
        public virtual IEnumerable<Category>? Categories { get; set; }
        public virtual IEnumerable<Manufactor>? Manufactors { get; set; }
        public virtual IEnumerable<ProductDto>? Products { get; set; }

    }
}
