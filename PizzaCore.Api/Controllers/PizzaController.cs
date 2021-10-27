using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.CrustService;
using PizzaCore.Business.PizzaService;
using PizzaCore.Business.ToppingService;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IToppingService _toppingService;
        private readonly ICrustService _crustService;
        private readonly IPizzaService _pizzaService;

        public PizzaController(IToppingService toppingService, ICrustService crustService, IPizzaService pizzaService)
        {
            _toppingService = toppingService;
            _crustService = crustService;
            _pizzaService = pizzaService;
        }

        // TOPPING ENDPOINTS
        [HttpPost]
        [Route("create_new_topping")]
        public async Task<IActionResult> SaveTopping([FromBody] ToppingRequest model)
        {
            return Ok(_toppingService.SaveTopping(model));
        }

        [HttpPost]
        [Route("create_topping_pricing")]
        public async Task<IActionResult> SaveToppingPricing([FromBody] List<PricesRequest> list)
        {
            return Ok(_toppingService.SaveToppingPrices(list));
        }

        [HttpGet]
        [Route("topping_list")]
        public async Task<IActionResult> ToppingList()
        {
            return Ok(new
            {
                data = _toppingService.GetAllToppings()
            });
        }

        [HttpGet]
        [Route("topping_prices_list")]
        public async Task<IActionResult> ToppingPriceList(int id)
        {
            return Ok(new
            {
                data = _toppingService.GetPricesByTopping(id)
            });
        }
        [HttpGet]
        [Route("topping_prices_list_by_size")]
        public async Task<IActionResult> ToppingPriceListBySize(int id)
        {
            return Ok(new
            {
                data = _toppingService.GetPricesBySize(id)
            });
        }
        [HttpGet]
        [Route("ingredients_list_by_pizza")]
        public async Task<IActionResult> IngredientListByPizza(int id)
        {
            return Ok(new
            {
                data = _pizzaService.GetIngredientsForByPizza(id)
            });
        }

        // CRUST ENDPOINTS
        [HttpPost]
        [Route("create_crust")]
        public async Task<IActionResult> SaveToppingCrust([FromBody] CrustDto data)
        {
            return Ok(_crustService.SaveCrust(data));
        }

        [HttpPost]
        [Route("create_crust_pricing")]
        public async Task<IActionResult> SaveCrustPricing([FromBody] List<PricesRequest> list)
        {
            return Ok(_crustService.SaveCrustPrices(list));
        }

        [HttpGet]
        [Route("crust_list")]
        public async Task<IActionResult> CrustList()
        {
            return Ok(new
            {
                data = _crustService.GetAllCrusts()
            });
        }

        [HttpGet]
        [Route("crust_prices_list")]
        public async Task<IActionResult> CrustPriceList(int id)
        {
            return Ok(new
            {
                data = _crustService.GetPricesForCrust(id)
            });
        }

        [HttpGet]
        [Route("crust_prices_by_size")]
        public async Task<IActionResult> CrustPriceListBySize(int id)
        {
            return Ok(new
            {
                data = _crustService.GetCrustPricesForSize(id)
            });
        }

        // PIZZA ENDPOINTS
        [HttpPost]
        [Route("create_new_pizza")]
        public async Task<IActionResult> SavePizza([FromBody] PizzaRequest model)
        {
            return Ok(_pizzaService.SavePizza(model));
        }

        [HttpPost]
        [Route("create_pizza_pricing")]
        public async Task<IActionResult> SavePizzaPricing([FromBody] List<PricesRequest> list)
        {
            return Ok(_pizzaService.SavePizzaPrices(list));
        }

        [HttpPost]
        [Route("create_pizza_ingredients")]
        public async Task<IActionResult> SavePizzaIngredients([FromBody] List<IngredientRequest> list)
        {
            return Ok(_pizzaService.SavePizzaIngredients(list));
        }

        [HttpGet]
        [Route("pizza_list_by_category")]
        public async Task<IActionResult> PizzaListBySub(int id)
        {
            return Ok(new
            {
                data = _pizzaService.GetPizzaByCategory(id)
            });
        }

        [HttpGet]
        [Route("pizza_prices")]
        public async Task<IActionResult> PizzaPriceList(int id)
        {
            return Ok(new
            {
                data = _pizzaService.GetPizzaPrices(id)
            });
        }
    }
}