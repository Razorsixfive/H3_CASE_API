using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IOrdersRepos
    {

        IEnumerable<Orders> GetOrders();
        Orders GetOrder(int Id);
        Task<bool> AddOrder(InputDataModels.Post_Order order);
        OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders);
        Task<bool> UpdateOrder(int OrderID, Orders order);
        bool OrderExists(int Id);
        OrdersDto FindTotalPrice(OrdersDto OrdersDto);
        bool Save();

    }
}
