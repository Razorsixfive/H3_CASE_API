using System;
using H3_CASE_API.Models;
using H3_CASE_API.Dto;
using H3_CASE_API.Repository;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace H3_CASE_API.Repository.Repos
{
    public class WarehouseRepos : IWarehouseRepos
    {
        private readonly MainDBContext _context;

        public WarehouseRepos(MainDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Warehouse GetWarehouse(int Id)
        {
            var Warehouse = _context.Warehouse
                .Include(x=>x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .Include(x=>x.Product_Stocks)
                    .ThenInclude(Product_Stocks => Product_Stocks.Product)
                .Include(x=>x.Department)
                .FirstOrDefault(a => a.WarehouseID == Id);

            if (Warehouse == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return Warehouse;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            var Warehouses = _context.Warehouse
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .Include(x => x.Product_Stocks)
                    .ThenInclude(Product_Stocks => Product_Stocks.Product)
                .Include(x => x.Department);
            return Warehouses;

        }

        public async Task<bool> AddWarehouse(InputDataModels.PostPut_Warehouse warehouse)
        {
            var _Department = await _context.Department.FindAsync(warehouse.DepartmentID);
            var _PostalCode = await _context.PostalCodes.FindAsync(warehouse.PostalCode);

            if (_Department == null || _PostalCode == null){
                return false;
            }

            var _ContactInformation = new Contact_Informaition();
            _ContactInformation.Contact_TypeID = warehouse.ContactTypeID;
            _ContactInformation.Email = warehouse.Email;
            _ContactInformation.First_Name = warehouse.First_Name;
            _ContactInformation.Last_Name = warehouse.Last_Name;
            _ContactInformation.Phone_Number = warehouse.Phone_Number;
            _ContactInformation.Mobile_Number = warehouse.Mobile_Number;
            _context.Contact_Informaition.Add(_ContactInformation);
            await _context.SaveChangesAsync();

            var _Addrese = new Addrese();
            _Addrese.Contact_InformaitionID = _ContactInformation.Contact_InformaitionID;
            _Addrese.Addrese_Name = warehouse.Addrese_Name;
            _Addrese.PostalCode = warehouse.PostalCode;
            _context.Addrese.Add(_Addrese);
            await _context.SaveChangesAsync();


            var _Warehouse = new Warehouse();
            _Warehouse.DepartmentID = _Department.DepartmentID;
            _Warehouse.Contact_InformaitionID = _ContactInformation.Contact_InformaitionID;
            _context.Warehouse.Add(_Warehouse);
            await _context.SaveChangesAsync();

            foreach (Product _Product in _context.Product)
            {
                Product_Stock _Stock = new Product_Stock();

                _Stock.WarehouseID = _Warehouse.WarehouseID;
                _Stock.ProductID = _Product.ProductID;
                _Stock.Ammount = 0;

                _context.Product_Stock.Add(_Stock);
            }
            await _context.SaveChangesAsync();


            return true;
        }

        public Task<Warehouse> UpdateWarehouse(InputDataModels.PostPut_Warehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public bool WarehouseExists(int Id)
        {
            return _context.Warehouse.Any(e => e.WarehouseID == Id);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<bool> UpdateWarehouseStock(int productID, int Ammount, Warehouse warehouse)
        {
            var result = await _context.Product_Stock
                .Where(x => x.WarehouseID == warehouse.WarehouseID)
                .FirstOrDefaultAsync(e => e.ProductID == productID);

            if(result != null){
                result.Ammount = Ammount;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
