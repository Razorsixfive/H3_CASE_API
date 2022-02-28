using System;
using H3_CASE_API.Models;
using H3_CASE_API.Repository;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace H3_CASE_API.Repository.Repos
{
    public class CustomerRepos : ICustomerRepos 
    {
        private readonly MainDBContext _context;

        public CustomerRepos(MainDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddCustomer(InputDataModels.PostCustomer _input)
        {
            var _Customer = new Customer(_input);

            _context.Contact_Informaition.Add(_Customer.Contact_Informaition);
            _context.SaveChanges();

            foreach(InputDataModels.Post_Addrese _Addrese in _input.addreses){
                _context.Addrese.Add(new Addrese(_Addrese, _Customer.Contact_Informaition.Contact_InformaitionID));
                _context.SaveChanges();
            }

            _context.Customer.Add(_Customer);
            _context.SaveChanges();

            return true;
        }

        public bool CustomerExists(int Id)
        {
            return _context.Customer.Any(e => e.CustomerID == Id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var data = _context.Customer
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Contact_Type)
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .ToList();

            return data;
        }

        public Customer GetCustomer(int Id)
        {
            var data = _context.Customer
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Contact_Type)
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .FirstOrDefault(x => x.CustomerID == Id);
            return data;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<Customer> UpdateCustomer(int CustomerID, InputDataModels.PutCustomer _input)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x=>x.CustomerID == CustomerID);
            var _Contact = await _context.Contact_Informaition.FirstOrDefaultAsync(x=>x.Contact_InformaitionID == customer.Contact_InformaitionID);
            _Contact.Contact_TypeID = _input.ContactTypeID;
            _Contact.Email = _input.Email;
            _Contact.First_Name = _input.First_Name;
            _Contact.Last_Name = _input.Last_Name;
            _Contact.Phone_Number = _input.Phone_Number;
            _Contact.Mobile_Number = _input.Mobile_Number;

            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Addrese> AddCustomer_Addrese(int CustomerID, InputDataModels.Post_Addrese _input)
        {
            var _Customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerID == CustomerID);
            var _Contact  = await _context.Contact_Informaition.FirstOrDefaultAsync(x => x.Contact_InformaitionID == _Customer.Contact_InformaitionID);

            var _Addrese = new Addrese(_input, _Contact.Contact_InformaitionID);
            _context.Addrese.Add(_Addrese);
            await _context.SaveChangesAsync();
            return _Addrese;
        }

        public async Task<bool> DeleteCustomer_Addrese(int AddreseID)
        {
            var _Addrese = await _context.Addrese.FindAsync(AddreseID);
            _context.Addrese.Remove(_Addrese);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Addrese> UpdateCustomer_Addrese(int AddreseID, InputDataModels.Post_Addrese _input)
        {
            var _Addrese = await _context.Addrese.FindAsync(AddreseID);
            _Addrese.Addrese_Name = _input.Addrese_Name;
            _Addrese.PostalCode = _input.PostalCode;
            _context.SaveChangesAsync();
            return _Addrese;
        }
    }
}
