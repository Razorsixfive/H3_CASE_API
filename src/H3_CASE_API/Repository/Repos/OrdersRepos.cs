using H3_CASE_API.DBContext;
using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;
using H3_CASE_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> AddOrder(InputDataModels.Put_Order order)
        {
            if (order == null) { return false; }

            Orders orders = new Orders(order);
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            foreach (InputDataModels.Put_OrderLine Orderline in order.OrderLines)
            {
                var result = await _context.Product
                    .FirstOrDefaultAsync(e => e.ProductID == Orderline.ProductID);

                if (result != null)
                {
                    _context.OrderLine.Add(new OrderLine(Orderline, result.Out_Price, orders.OrdersID));
                    await _context.SaveChangesAsync();
                }
            }

            return true;
        }

        public Task<Orders> UpdateOrder(int OrderID, Orders order)
        {
            //var _Addrese = await _context.Addrese.FindAsync(AddreseID);
            //_Addrese.Addrese_Name = _input.Addrese_Name;
            //_Addrese.PostalCode = _input.PostalCode;
            //_context.SaveChangesAsync();
            //return _Addrese;

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrder(int OrderID)
        {
            var Order = await _context.Orders.Include(x => x.OrderLines)
                .FirstOrDefaultAsync(e => e.OrdersID == OrderID);

            if (Order == null)
            {
                return false;
            }

            foreach (OrderLine item in Order.OrderLines)
            {
                _context.OrderLine.Remove(item);
                await _context.SaveChangesAsync();
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool OrderExists(int Id)
        {
            return _context.Orders.Any(e => e.OrdersID == Id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        public IEnumerable<OrdersDto> FindTotalPrice(IEnumerable<OrdersDto> OrdersDto)
        {
            foreach (OrdersDto OrderDto in OrdersDto)
            {
                double Price = 0;
                foreach (OrderLineDto item in OrderDto.OrderLines)
                {
                    Price += item.Price;
                }
                OrderDto.TotalPrice = Price;

            }
            return OrdersDto;
        }

        public OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders)
        {
            //_OrdersView.Categories = _context.Category;
            //_OrdersView.Manufactors = _context.Manufactor;


            OrdersView _OrdersView = new OrdersView();
            _OrdersView.Delivery_Service = _context.Delivery_Service;
            _OrdersView.Orders = Orders;
            return _OrdersView;
        }

    }
}
