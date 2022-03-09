using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface ICustomerRepos
    {
        // Warehouses
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        Task<bool> AddCustomer(InputDataModels.PostCustomer _input);
        Task<Customer> UpdateCustomer(int CustomerID, InputDataModels.PutCustomer _input);
        Task<Addrese> AddCustomer_Addrese(int CustomerID, InputDataModels.Post_Addrese _input);
        Task<bool> DeleteCustomer_Addrese(int AddreseID);
        Task<Addrese> UpdateCustomer_Addrese(int AddreseID, InputDataModels.Post_Addrese _input);
        bool CustomerExists(int Id);
        bool Save();

    }
}
