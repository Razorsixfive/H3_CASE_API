using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IWarehouseRepos
    {

        IEnumerable<Warehouse> GetWarehouses();
        Task<Warehouse> UpdateWarehouse(int id, InputDataModels.PostPut_Warehouse warehouse);
        Task<bool> AddWarehouse(InputDataModels.PostPut_Warehouse warehouse);
        Task<bool> UpdateWarehouseStock(int productID, int Ammount, Warehouse warehouse);
        Warehouse GetWarehouse(int Id);
        bool WarehouseExists(int Id);
        bool Save();

    }
}
