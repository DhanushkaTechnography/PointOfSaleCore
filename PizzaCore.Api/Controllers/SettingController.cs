using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.OrderService;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Membership;

namespace PizzaCore.Controllers
{
    [Route("api/setting")]
    [ApiController]
    public class SettingController:ControllerBase
    {
        private readonly IOrderService _orderService;

        public SettingController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        // DELIVERY OPTIONS
        [HttpPost]
        [Route("save_delivery_option")]
        public async Task<IActionResult> NewDeliveryOption([FromBody] DeliveryOptionDto deliveryOption)
        {
            return Ok(_orderService.SaveDeliveryOption(deliveryOption));
        }
        [HttpGet]
        [Route("all_delivery_options")]
        public async Task<IActionResult> AllDeliveryOptions()
        {
            return Ok(new
            {
                data = _orderService.GetDeliveryOptions()
            });
        }
    }
}