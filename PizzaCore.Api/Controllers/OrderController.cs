using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.OrderService;
using PizzaCore.Entity.Membership;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderService:ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("new_order")]
        public async Task<IActionResult> NewOrder([FromBody] OrderRequest orderRequest)
        {
            return Ok(_orderService.SaveOrder(orderRequest));
        }
        [HttpGet]
        [Route("orders_by_status")]
        public async Task<IActionResult> OrdersByStatus(string status)
        {
            return Ok(new
            {
                data = _orderService.GetOrdersByStatus(status)
            });
        }
        [HttpGet]
        [Route("orders_by_customer")]
        public async Task<IActionResult> OrdersByCustomer(int id)
        {
            return Ok(new
            {
                data = _orderService.GetCustomerOrderList(id)
            });
        }
        [HttpGet]
        [Route("update_item_in_order")]
        public async Task<IActionResult> OrdersId(int id)
        {
            return Ok(new
            {
                data = _orderService.UpdateOrderOtherItemStatus(id)
            });
        }
        [HttpGet]
        [Route("update_pizza_in_order")]
        public async Task<IActionResult> PizzaOrderId(int id)
        {
            return Ok(new
            {
                data = _orderService.UpdateOrderPizzaItemStatus(id)
            });
        }
    }
}