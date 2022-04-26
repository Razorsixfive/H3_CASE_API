#nullable disable
using Microsoft.AspNetCore.Mvc;
using H3_CASE_API.Entities.Dto;
using H3_CASE_API.Entities.Views;
using H3_CASE_API.Entities;
using Microsoft.AspNetCore.Authorization;
using H3_CASE_API.Infrastructure.BasicAuth;

namespace H3_CASE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepos _ordersRepos;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public OrdersController(IOrdersRepos OrdersReposContext, IMapper mapper, LinkGenerator linkGenerator)
        {
            _ordersRepos = OrdersReposContext ?? throw new ArgumentNullException(nameof(OrdersReposContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }

        // GET: Orders
        //[Authorize]
        [HttpGet (Name = "GetAllOrders")]
        public IActionResult GetOrders()
        {
            var Order = _ordersRepos.GetOrders();
            if (Order == null)
            {
                return NotFound();
            }
            var MappedOrders = _mapper.Map<IEnumerable<OrdersDto>>(Order);

            foreach(OrdersDto _Order in MappedOrders){
                _ordersRepos.FindTotalPrice(_Order);
            }

            OrdersView View = _ordersRepos.FilterIntoView(MappedOrders);

            View.Links = CreateLinksForOrders(0, null);

            return Ok(View);
        }

        [BasicAuth]
        [HttpGet("{id}", Name ="GetOrderByID")]
        public IActionResult GetOrders(int id)
        {
            var Order = _ordersRepos.GetOrder(id);
            if(Order == null){
                return NotFound();
            }
            var MappedOrders = _mapper.Map<OrdersDto>(Order);
            _ordersRepos.FindTotalPrice(MappedOrders);
            MappedOrders.Links = CreateLinksForOrders(Order.OrdersID,null);

            return Ok(MappedOrders);
        }

        // PUT: Orders/
        [HttpPut (Name = "AddNewOrder")]
        public async Task<IActionResult> PutOrders(InputDataModels.Put_Order Order)
        {
            var result = await _ordersRepos.AddOrder(Order);
            if (result == false) { return NotFound(); }
            return Ok(result);
        }

        // POST: Orders
        [HttpPost (Name = "UpdateOrder")]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            //var Addrese = await _ordersRepos.UpdateOrder(orders);

            //if (Addrese == null)
            //{
            //    return BadRequest();
            //}

            //return Ok(Addrese);
            throw new NotImplementedException();
        }

        // DELETE: Orders/5
        [HttpDelete("{id}", Name = "DeleteOrderByID")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var result = await _ordersRepos.DeleteOrder(id);
            if (result == false){ return NotFound(); }
            return Ok(result);
        }


        private IEnumerable<Link> CreateLinksForOrders(int id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetOrders), values: new { id, fields }),
                "self",
                "GET"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteOrders), values: new { id }),
                "delete_order",
                "DELETE"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(PostOrders), values: new { id }),
                "update_order",
                "POST"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(PutOrders)),
                "Add_Order",
                "PUT")
            };

            return links;
        }
        private IEnumerable<Link> CreateLinksForSingleOrder(int id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(HttpContext, "/asdasd", values: new { id, fields }),
                "get customer",
                "GET"),
            };

            return links;
        }
    }
}
