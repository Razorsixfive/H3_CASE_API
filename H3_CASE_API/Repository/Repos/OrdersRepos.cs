using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Repos
{
    public class OrdersRepos : IOrdersRepos
    {
        private readonly MainDBContext _context;

        public OrdersRepos(MainDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Orders GetOrder(int Id)
        {
            var Order = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.Delivery_Service)
                .Include(x => x.OrderLines)
                .FirstOrDefault(x => x.OrdersID == Id);

            if (Order == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return Order;
        }

        public IEnumerable<Orders> GetOrders()
        {
            var Order = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.Delivery_Service)
                .Include(x => x.OrderLines);

            return Order;
        }

        public Task<bool> AddOrder(InputDataModels.Post_Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(int OrderID, Orders order)
        {
            throw new NotImplementedException();
        }

        public bool OrderExists(int Id)
        {
            return _context.Orders.Any(e => e.OrdersID == Id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        public OrdersDto FindTotalPrice(OrdersDto OrdersDto)
        {
            double Price = 0;
            foreach (OrderLineDto item in OrdersDto.OrderLines)
            {
                Price += item.Price;
            }
            OrdersDto.TotalPrice = Price;
            return OrdersDto;
        }

        public OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders)
        {
            OrdersView _OrdersView = new OrdersView();
                _OrdersView.Orders = Orders;
                _OrdersView.Categories = _context.Category;
                _OrdersView.Manufactors = _context.Manufactor;
            return _OrdersView;
        }
    }
}
