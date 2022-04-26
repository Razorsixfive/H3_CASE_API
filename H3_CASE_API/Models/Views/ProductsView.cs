using H3_CASE_API.Entities.Dto;
using H3_CASE_API.Entities;

namespace H3_CASE_API.Entities.Views
{
    public class ProductsView
    {
        public virtual IEnumerable<Category>? Categories { get; set; }
        public virtual IEnumerable<Manufactor>? Manufactors { get; set; }
        public virtual IEnumerable<ProductDto>? Products { get; set; }

    }
}
