#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CASE_API.DBContext;
using H3_CASE_API.Dto;
using H3_CASE_API.Models;
using AutoMapper;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepos _CustomerRepos;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepos CustomerReposContext,IMapper mapper)
        {
            _CustomerRepos = CustomerReposContext ??
                throw new ArgumentNullException(nameof(CustomerReposContext));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = _CustomerRepos.GetCustomers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(result));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var result = _CustomerRepos.GetCustomer(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(InputDataModels.PostCustomer _input)
        {
            if (await _CustomerRepos.AddCustomer(_input))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            if (!_CustomerRepos.CustomerExists(customer.CustomerID))
            {
                return NotFound();
            }

            if (await _CustomerRepos.UpdateCustomer(customer) == null)
            {
                return BadRequest();
            }

            _CustomerRepos.Save();
            return NoContent();
        }
    }
}
