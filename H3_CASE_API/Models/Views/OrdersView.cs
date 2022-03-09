using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;

namespace H3_CASE_API.Models.Views
{
    public class OrdersView
    {
        public virtual IEnumerable<Category>? Categories { get; set; }
        public virtual IEnumerable<Manufactor>? Manufactors { get; set; }
        public virtual IEnumerable<OrdersDto>? Orders { get; set; }

    }
}
