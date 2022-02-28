using H3_CASE_API.Models;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IWarehouseRepos
    {

        IEnumerable<Warehouse> GetWarehouses();
        Warehouse GetWarehouse(int Id);
        Task<bool> AddWarehouse(InputDataModels.PostPut_Warehouse warehouse);
        Task<bool> UpdateWarehouseStock(int productID, int Ammount, Warehouse warehouse);
        Task<Warehouse> UpdateWarehouse(int id,InputDataModels.PostPut_Warehouse warehouse);
        bool WarehouseExists(int Id);
        bool Save();

    }
}
