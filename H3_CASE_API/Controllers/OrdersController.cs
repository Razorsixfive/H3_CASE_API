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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepos _ordersRepos;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepos OrdersReposContext, IMapper mapper)
        {
            _ordersRepos = OrdersReposContext ?? throw new ArgumentNullException(nameof(OrdersReposContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Orders
        // FilterIntoView filters data into view with categories and manufactors
        [HttpGet]
        public IActionResult GetOrders()
        {
            var Order = _ordersRepos.GetOrders();
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(_ordersRepos.FilterIntoView(_mapper.Map<IEnumerable<OrdersDto>>(Order)));

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var Order = _ordersRepos.GetOrder(id);
            if(Order == null){
                return NotFound();
            }
            return Ok(_ordersRepos.FindTotalPrice(_mapper.Map<OrdersDto>(Order)));
        }

        // PUT: api/Orders/
        [HttpPut]
        public async Task<IActionResult> PutOrders(Orders orders)
        {
            throw new NotImplementedException();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            throw new NotImplementedException();

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            throw new NotImplementedException();

        }
    }
}
