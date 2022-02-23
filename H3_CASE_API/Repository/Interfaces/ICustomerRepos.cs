using H3_CASE_API.Models;
using H3_CASE_API.Dto;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface ICustomerRepos
    {
        // Warehouses
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        Task<bool> AddCustomer(InputDataModels.PostCustomer _input);
        Task<Customer> UpdateCustomer(Customer Customer);
        bool CustomerExists(int Id);
        bool Save();

    }
}
