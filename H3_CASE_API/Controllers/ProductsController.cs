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


namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepos _productRepos;
        private readonly IMapper _mapper;


        public ProductsController(IProductRepos ProductReposContext, IMapper mapper)
        {
            _productRepos = ProductReposContext ??
                throw new ArgumentNullException(nameof(ProductReposContext));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepos.GetProducts();
            if(products == null){
                return NotFound();
            }
            return Ok(_productRepos.FilterIntoView(_mapper.Map<IEnumerable<ProductDto>>(products)));

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepos.GetProduct(id);
            if (product == null){
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("Category/{Category_id}")]
        public IActionResult GetProduct_ByCategory(int Category_id)
        {
            var product = _productRepos.GetProducts_ByCategory(Category_id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [HttpGet("Manufactor/{Manufactor_ID}")]
        public IActionResult GetProduct_ByManufactor(int Manufactor_ID)
        {
            var product = _productRepos.GetProducts_ByManufactor(Manufactor_ID);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(InputDataModels.PostProduct product)
        {
            if (_productRepos.ProductExists(product.ProductID)){
                return BadRequest();
            }

            if (await _productRepos.AddProduct(product)){
                return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product Product)
        {
            if (!_productRepos.ProductExists(Product.ProductID))
            {
                return NotFound();
            }

            var result = await _productRepos.UpdateProduct(Product);
            if (result == null) {
                return BadRequest();
            }

            _productRepos.Save();
            return NoContent();
        }
    }
}

