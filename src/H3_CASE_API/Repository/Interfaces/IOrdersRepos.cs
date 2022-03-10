using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IOrdersRepos
    {

        IEnumerable<Orders> GetOrders();
        Orders GetOrder(int Id);
        Task<bool> AddOrder(InputDataModels.Put_Order order);
        OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders);
        Task<Orders> UpdateOrder(int OrderID, Orders order);
        Task<bool> DeleteOrder(int OrderID);
        IEnumerable<OrdersDto> FindTotalPrice(IEnumerable<OrdersDto> OrdersDto);
        bool OrderExists(int Id);
        bool Save();

    }
}
