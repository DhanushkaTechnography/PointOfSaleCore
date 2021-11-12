using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.ItemService;
using PizzaCore.Entity.Membership;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController:ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        [Route("new_item")]
        public async Task<IActionResult> NewMembership([FromBody] ItemRequest model)
        {
            return Ok(_itemService.SaveNewItem(model));
        }
        [HttpGet]
        [Route("item_list_all")]
        public async Task<IActionResult> ItemList()
        {
            return Ok(new
            {
                data = _itemService.GetItemList()
            });
        }
        [HttpGet]
        [Route("items_by_category")]
        public async Task<IActionResult> ItemByCategory(int id)
        {
            return Ok(new
            {
                data = _itemService.GetByCategory(id)
            });
        }
    }
}