#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using H3_CASE_API.Models.Views;
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
            _CustomerRepos = CustomerReposContext ?? throw new ArgumentNullException(nameof(CustomerReposContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id ,InputDataModels.PutCustomer _input)
        {
            if (!_CustomerRepos.CustomerExists(id))
            {
                return NotFound();
            }

            if (await _CustomerRepos.UpdateCustomer(id,_input) == null)
            {
                return BadRequest();
            }

            _CustomerRepos.Save();
            return NoContent();
        }

        [HttpPost("Addrese/{CustomerID}")]
        public async Task<IActionResult> AddAddrese(int CustomerID, InputDataModels.Post_Addrese _input)
        {
            var data = await _CustomerRepos.AddCustomer_Addrese(CustomerID, _input);
            return Ok(data);
        }


        [HttpDelete("Addrese/{AddreseID}")]
        public async Task<IActionResult> DeleteAddrese(int AddreseID)
        {
            var data = await _CustomerRepos.DeleteCustomer_Addrese(AddreseID);
            return Ok(data);
        }


        [HttpPut("Addrese/{AddreseID}")]
        public async Task<IActionResult> UpdateAddrese(int AddreseID, InputDataModels.Post_Addrese _input)
        {
            var data = await _CustomerRepos.UpdateCustomer_Addrese(AddreseID, _input);
            return Ok(data);
        }
    }
}
