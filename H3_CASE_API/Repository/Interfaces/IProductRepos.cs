using H3_CASE_API.Models;
using H3_CASE_API.Dto;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IProductRepos
    {

        IEnumerable<Product> GetProducts();
        Product GetProduct(int Id);
        Task<bool> AddProduct(InputDataModels.PostProduct Product);
        Task<Product> UpdateProduct(Product Product);
        bool ProductExists(int Id);
        bool Save();

    }
}
