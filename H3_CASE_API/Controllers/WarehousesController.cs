#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CASE_API.Repository;
using H3_CASE_API.DBContext;
using H3_CASE_API.Models;
using H3_CASE_API.Dto;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseRepos _warehouseRepos;
        private readonly IMapper _mapper;

        public WarehousesController(IWarehouseRepos WarehouseReposContext, IMapper mapper)
        {
            _warehouseRepos = WarehouseReposContext ??
                throw new ArgumentNullException(nameof(WarehouseReposContext));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Warehouses
        [HttpGet]
        public IActionResult GetWarehouses()
        {
            var Warehouses = _warehouseRepos.GetWarehouses();
            if (Warehouses == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<WarehousesDto>>(Warehouses));

        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public IActionResult GetWarehouse(int id)
        {
            var Warehouse = _warehouseRepos.GetWarehouse(id);

            if (Warehouse == null)
            {
                return NotFound();
            }

            WarehousesDto warehousedto = _mapper.Map<WarehousesDto>(Warehouse);
            return Ok(warehousedto);

        }

        // PUT: api/Warehouses/5
        [HttpPut]
        public async Task<IActionResult> PutWarehouse(InputDataModels.PostPut_Warehouse warehouse)
        {
            if (await _warehouseRepos.AddWarehouse(warehouse)){
                return Ok();
            }

            return BadRequest();
        }

        // PUT: api/Warehouses/2/5/65
        [HttpPut("{warehouseID}/{productID}/{Ammount}")]
        public async Task<IActionResult> PutWarehouseStock(int warehouseID, int productID, int Ammount){
            var warehouse = _warehouseRepos.GetWarehouse(warehouseID);
            if (warehouse == null){
                return NotFound();
            }

            if (await _warehouseRepos.UpdateWarehouseStock(productID, Ammount, warehouse)){
                return Ok();
            }

            return BadRequest();

        }

        // POST: api/Warehouses
        [HttpPost("{id}")]
        public async Task<IActionResult> PostWarehouse(int id,InputDataModels.PostPut_Warehouse warehouse)
        {
            var data = await _warehouseRepos.UpdateWarehouse(id, warehouse);
            return Ok(data);
        }
    }
}