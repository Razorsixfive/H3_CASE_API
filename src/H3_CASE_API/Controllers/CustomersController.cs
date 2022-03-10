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
using H3_CASE_API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        //[Authorize]
        [Route("GetCustomer")]
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
        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        [Route("{id}")]
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
        [AllowAnonymous]
        //[Authorize]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(InputDataModels.PostCustomer _input)
        {
            if (await _CustomerRepos.AddCustomer(_input))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [AllowAnonymous]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id ,InputDataModels.PutCustomer _input)
        {
            if (!_CustomerRepos.CustomerExists(id))
            {
                return NotFound();
            }

            if (await _CustomerRepos.UpdateCustomer(id, _input) == null)
            {
                return BadRequest();
            }

            _CustomerRepos.Save();
            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize]
        [Route("Addrese/{AddreseID}")]
        public async Task<ActionResult<Addrese>> AddAddrese(int CustomerID, InputDataModels.Post_Addrese _input)
        {
            var Addrese = await _CustomerRepos.AddCustomer_Addrese(CustomerID, _input);

            if (Addrese == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCustomer", new { id = Addrese.AddreseID }, Addrese);

        }

        [HttpDelete]
        [AllowAnonymous]
        //[Authorize]
        [Route("Addrese/{AddreseID}")]
        public async Task<IActionResult> DeleteAddrese(int AddreseID)
        {
            if (await _CustomerRepos.DeleteCustomer_Addrese(AddreseID))
            {
                return NoContent();
            }

            return BadRequest();
        }


        [HttpPut]
        [AllowAnonymous]
        //[Authorize]
        [Route("Addrese/{AddreseID}")]
        public async Task<IActionResult> UpdateAddrese(int AddreseID, InputDataModels.Post_Addrese _input)
        {
            var Addrese = await _CustomerRepos.UpdateCustomer_Addrese(AddreseID, _input);

            if (Addrese == null)
            {
                return BadRequest();
            }

            return Ok(Addrese);
        }
    }
}
