using System;
using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
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
            var data = await Dismalte_PostPut(warehouse);
            var Contact = data.Item1;
            var Warehouse = data.Item2;
            var Addreses = data.Item3;

            _context.Contact_Informaition.Add(Contact);
            await _context.SaveChangesAsync();

            foreach(Addrese _Addrese in Addreses){
                _context.Addrese.Add(_Addrese);
            }
            await _context.SaveChangesAsync();

            _context.Warehouse.Add(Warehouse);
            await _context.SaveChangesAsync();

            foreach (Product _Product in _context.Product)
            {
                Product_Stock _Stock = new Product_Stock();

                _Stock.WarehouseID = Warehouse.WarehouseID;
                _Stock.ProductID = _Product.ProductID;
                _Stock.Ammount = 0;

                _context.Product_Stock.Add(_Stock);
            }
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Warehouse> UpdateWarehouse(int id, InputDataModels.PostPut_Warehouse warehouse)
        {
            throw new NotImplementedException();
            //var data = await Dismalte_PostPut(warehouse);
            //var Contact = data.Item1;
            //var Warehouse = data.Item2;

            //var _OldWarehouse = await _context.Warehouse.FirstOrDefaultAsync(e => e.WarehouseID == id);
            //var _OldContact = await _context.Contact_Informaition.FirstOrDefaultAsync(e => e.Contact_InformaitionID == _OldWarehouse.Contact_InformaitionID);

            //_OldWarehouse = Warehouse;
            //_OldContact = Contact;

            //await _context.SaveChangesAsync();
            //return Warehouse;
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

        public async Task<Tuple<Contact_Informaition, Warehouse, List<Addrese>>> Dismalte_PostPut(InputDataModels.PostPut_Warehouse warehouse)
        {
            var _ContactInformation = new Contact_Informaition();
                _ContactInformation.Contact_TypeID = warehouse.ContactTypeID;
                _ContactInformation.Email = warehouse.Email;
                _ContactInformation.First_Name = warehouse.First_Name;
                _ContactInformation.Last_Name = warehouse.Last_Name;
                _ContactInformation.Phone_Number = warehouse.Phone_Number;
                _ContactInformation.Mobile_Number = warehouse.Mobile_Number;

            var _Warehouse = new Warehouse();
                _Warehouse.DepartmentID = warehouse.DepartmentID;
                _Warehouse.Contact_InformaitionID = _ContactInformation.Contact_InformaitionID;

            List<Addrese> addreses = new List<Addrese>();

            foreach (InputDataModels.Post_Addrese Addrese in warehouse.Addreses)
            {
                var _Addrese = new Addrese();
                    _Addrese.Contact_InformaitionID = _ContactInformation.Contact_InformaitionID;
                    _Addrese.Addrese_Name = Addrese.Addrese_Name;
                    _Addrese.PostalCode = Addrese.PostalCode;
                addreses.Add(_Addrese);
            }

            return Tuple.Create(_ContactInformation, _Warehouse, addreses);
        }

    }
}
