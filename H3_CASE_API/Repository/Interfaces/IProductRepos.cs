using H3_CASE_API.Models;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IProductRepos
    {

        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts_ByCategory(int id);
        IEnumerable<Product> GetProducts_ByManufactor(int id);
        Product GetProduct(int Id);
        Task<bool> AddProduct(InputDataModels.PostProduct Product);
        Task<Product> UpdateProduct(Product Product);
        bool ProductExists(int Id);
        bool Save();

    }
}
