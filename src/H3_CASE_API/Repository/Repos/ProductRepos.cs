using H3_CASE_API.DBContext;
using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;
using H3_CASE_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace H3_CASE_API.Repository.Repos
{
    public class ProductRepos : IProductRepos
    {
        private readonly MainDBContext _context;

        public ProductRepos(MainDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddProduct(InputDataModels.PostProduct Product)
        {
            var _Category = await _context.Category.FindAsync(Product.CategoryID);
            var _Manufactor = await _context.Manufactor.FindAsync(Product.ManufactorID);

            if (_Category == null || _Manufactor == null)
            {
                return false;
            }

            var _product = new Product();
            _product.Product_Name = Product.Product_Name;
            _product.Product_Description = Product.Product_Description;
            _product.In_Price = Product.In_Price;
            _product.Out_Price = Product.Out_Price;
            _product.Category = _Category;
            _product.Manufactor = _Manufactor;

            _context.Product.Add(_product);
            await _context.SaveChangesAsync();

            foreach (Warehouse warehouse in _context.Warehouse)
            {
                Product_Stock _Stock = new Product_Stock();

                _Stock.WarehouseID = warehouse.WarehouseID;
                _Stock.ProductID = _product.ProductID;
                _Stock.Ammount = 0;

                _context.Product_Stock.Add(_Stock);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public Product GetProduct(int Id)
        {
            var Product = _context.Product
                .Include(x => x.Manufactor)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.ProductID == Id);

            if (Product == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return Product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var data = _context.Product
                .Include(x => x.Manufactor)
                .Include(x => x.Category);
            return data;
        }
        public async Task<Product> UpdateProduct(Product Product)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(e => e.ProductID == Product.ProductID);
            var categ = await _context.Category
                .FirstOrDefaultAsync(e => e.CategoryID == Product.CategoryID);
            var manuf = await _context.Manufactor
                .FirstOrDefaultAsync(e => e.ManufactorID == Product.ManufactorID);

            if (result != null)
            {
                result.Product_Name = Product.Product_Name;
                result.Product_Description = Product.Product_Description;
                result.In_Price = Product.In_Price;
                result.Out_Price = Product.Out_Price;
                result.Category = categ;
                result.Manufactor = manuf;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public IEnumerable<Product> GetProducts_ByCategory(int id)
        {
            var data = _context.Product
                .Include(x => x.Manufactor)
                .Include(x => x.Category)
                .Where(x => x.CategoryID == id);
            return data;
        }

        public IEnumerable<Product> GetProducts_ByManufactor(int id)
        {
            var data = _context.Product
                .Include(x => x.Manufactor)
                .Include(x => x.Category)
                .Where(x => x.ManufactorID == id);
            return data;
        }
        public ProductsView FilterIntoView(IEnumerable<ProductDto> Products)
        {
            ProductsView _ProductsView = new ProductsView();
            _ProductsView.Products = Products;
            _ProductsView.Categories = _context.Category;
            _ProductsView.Manufactors = _context.Manufactor;
            return _ProductsView;
        }

        public bool ProductExists(int Id)
        {
            return _context.Product.Any(e => e.ProductID == Id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
