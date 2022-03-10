#nullable disable
using Microsoft.AspNetCore.Mvc;
using H3_CASE_API.Models;
using H3_CASE_API.Models.Dto;
using AutoMapper;
using H3_CASE_API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        //[Authorize]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _productRepos.GetProducts();
            if(products == null){
                return NotFound();
            }
            return Ok(_productRepos.FilterIntoView(_mapper.Map<IEnumerable<ProductDto>>(products)));

        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        [Route("GetProducts/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepos.GetProduct(id);
            if (product == null){
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        [Route("Category/{Category_id}")]
        public IActionResult GetProduct_ByCategory(int Category_id)
        {
            var product = _productRepos.GetProducts_ByCategory(Category_id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        [Route("Manufactor/{Manufactor_ID}")]
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
        [AllowAnonymous]
        //[Authorize]
        [Route("PostProduct")]
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
        [AllowAnonymous]
        //[Authorize]
        [Route("UpdateProduct")]
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

