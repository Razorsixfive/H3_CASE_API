using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;

namespace H3_CASE_API.Repository.Interfaces
{
    public interface IProductRepos
    {

        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts_ByCategory(int id);
        IEnumerable<Product> GetProducts_ByManufactor(int id);
        Task<Product> UpdateProduct(Product Product);
        Task<bool> AddProduct(InputDataModels.PostProduct Product);
        ProductsView FilterIntoView(IEnumerable<ProductDto> Products);
        Product GetProduct(int Id);
        bool ProductExists(int Id);
        bool Save();

    }
}
