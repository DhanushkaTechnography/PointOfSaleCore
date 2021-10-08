using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.SizesService;
using PizzaCore.Entity.Sizes;

namespace PizzaCore.Controllers
{
    [Route("api/sizes")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizesService _service;

        public SizesController(ISizesService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("create_new")]
        public async Task<IActionResult> SaveCategory([FromBody] SizesDto model)
        {
            if (_service.CreateSizes(model))
            {
                return Ok(true);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("all_sizes")]
        public async Task<IActionResult> CategoryList()
        {
            return Ok(new
            {
                data = _service.GetAllSizes()
            });
        }
        [HttpGet]
        [Route("active_sizes")]
        public async Task<IActionResult> ActiveList()
        {
            return Ok(new
            {
                data = _service.GetActiveSizes()
            });
        }
    }
}