using H3_CASE_API.Entities.Dto;
using H3_CASE_API.Entities;

namespace H3_CASE_API.Entities.Views
{
    public class OrdersView
    {
        //public virtual IEnumerable<Category>? Categories { get; set; }
        //public virtual IEnumerable<Manufactor>? Manufactors { get; set; }

        public virtual IEnumerable<Delivery_Service>? Delivery_Service { get; set; }
        public virtual IEnumerable<OrdersDto>? Orders { get; set; }
        public virtual IEnumerable<Link>? Links { get; set; }
    }
}
