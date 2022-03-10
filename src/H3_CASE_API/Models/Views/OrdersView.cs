using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;

namespace H3_CASE_API.Models.Views
{
    public class OrdersView
    {
        public virtual IEnumerable<Delivery_Service>? Delivery_Service { get; set; }
        public virtual IEnumerable<OrdersDto>? Orders { get; set; }
        public virtual IEnumerable<Link>? Links { get; set; }

    }
}
