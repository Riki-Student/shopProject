using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        // GET: api/<OrderItemController>
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> Get()
        {
            List<OrderItem> orderItems = await _orderItemService.GetOrderItems();
            return orderItems == null ? NoContent() : Ok(orderItems);

        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> Get(int orderId)
        {
            OrderItem orderItem = await _orderItemService.GetOrderItemByOrderId(orderId);
            return orderItem == null ? NoContent() : Ok(orderItem);
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<ActionResult<OrderItem>> Post([FromBody] OrderItem newOrderItem)
        {
            OrderItem orderItem = await _orderItemService.CreateOrderItem(newOrderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, orderItem);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
