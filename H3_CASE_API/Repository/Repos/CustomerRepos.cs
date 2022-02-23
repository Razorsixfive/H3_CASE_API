using System;
using H3_CASE_API.Models;
using H3_CASE_API.Dto;
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

            //_context.Customer.Add(_input);
            //await _context.SaveChangesAsync();

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

        public Task<Customer> UpdateCustomer(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
