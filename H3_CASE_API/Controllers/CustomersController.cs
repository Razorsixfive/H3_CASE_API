#nullable disable
using Microsoft.AspNetCore.Mvc;
using H3_CASE_API.Entities;
using H3_CASE_API.Entities.Dto;
using H3_CASE_API.Entities.Views;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepos _CustomerRepos;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CustomersController(ICustomerRepos CustomerReposContext,IMapper mapper, LinkGenerator linkGenerator)
        {
            _CustomerRepos = CustomerReposContext ?? throw new ArgumentNullException(nameof(CustomerReposContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }

        // GET: Customers
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = _CustomerRepos.GetCustomers();
            if (result == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<IEnumerable<CustomerDto>>(result);
            foreach (var item in mapped)
            {
                item.Links = CreateLinksForSingleCustomer(item.CustomerID,null);
            }
            return Ok(mapped);

        }

        // GET: Customers/5
        [HttpGet("{CustomerID}")]
        public IActionResult GetCustomer(int CustomerID)
        {
            var result = _CustomerRepos.GetCustomer(CustomerID);
            if (result == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<CustomerDto>(result);
            mapped.Links = CreateLinksForCustomer(CustomerID, "addreseid",null);
            return Ok(mapped);

        }

        [HttpGet("{CustomerID}/Orders")]
        public IActionResult GetCustomerOrders(int CustomerID)
        {
            var Order = _CustomerRepos.GetCustomerOrders(CustomerID);
            if (Order == null)
            {
                return NotFound();
            }
            var MappedOrders = _mapper.Map<IEnumerable<OrdersDto>>(Order);

            foreach (OrdersDto _Order in MappedOrders)
            {
                _CustomerRepos.FindTotalPrice(_Order);
            }

            OrdersView View = _CustomerRepos.FilterIntoView(MappedOrders);

            //View.Links = CreateLinksForOrders(0, null);

            return Ok(View);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(InputDataModels.PostCustomer _input)
        {
            if (await _CustomerRepos.AddCustomer(_input)){
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{CustomerID}")]
        public async Task<IActionResult> UpdateCustomer(int CustomerID, InputDataModels.PutCustomer _input)
        {
            if (!_CustomerRepos.CustomerExists(CustomerID))
            {
                return NotFound();
            }

            if (await _CustomerRepos.UpdateCustomer(CustomerID, _input) == null)
            {
                return BadRequest();
            }

            _CustomerRepos.Save();
            return NoContent();
        }

        [HttpPost("Addrese/{CustomerID}")]
        public async Task<ActionResult<Addrese>> AddAddrese(int CustomerID, InputDataModels.Post_Addrese _input)
        {
            var Addrese = await _CustomerRepos.AddCustomer_Addrese(CustomerID, _input);

            if (Addrese == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCustomer", new { id = Addrese.AddreseID }, Addrese);

        }

        [HttpPut("Addrese/{CustomerID}/{AddreseID}")]
        public async Task<IActionResult> UpdateAddrese(int AddreseID, InputDataModels.Post_Addrese _input, int CustomerID)
        {
            var Addrese = await _CustomerRepos.UpdateCustomer_Addrese(AddreseID, _input, CustomerID);

            if (Addrese == false)
            {
                return BadRequest();
            }

            return Ok(Addrese);
        }

        [HttpDelete("Addrese/{CustomerID}/{AddreseID}")]
        public async Task<IActionResult> DeleteAddrese(int CustomerID,int AddreseID)
        {
            if (await _CustomerRepos.DeleteCustomer_Addrese(AddreseID, CustomerID))
            {
                return NoContent();
            }

            return BadRequest();
        }

        private IEnumerable<Link> CreateLinksForCustomer(int CustomerID, string AddreseID, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCustomer), values: new { CustomerID, fields }),
                "self",
                "GET"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(AddAddrese), values: new { CustomerID }),
                "add_Addrese",
                "POST"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateAddrese), values: new { AddreseID , CustomerID}),
                "delete_Addrese",
                "DELETE"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteAddrese), values: new { AddreseID , CustomerID}),
                "update_Addrese",
                "PUT"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCustomerOrders), values: new { CustomerID }),
                "Customer Orders",
                "GET")
            };

            return links;
        }
        private IEnumerable<Link> CreateLinksForSingleCustomer(int CustomerID, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCustomer), values: new { CustomerID, fields }),
                "self",
                "GET"),
            };

            return links;
        }

    }
}
