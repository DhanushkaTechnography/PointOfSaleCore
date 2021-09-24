using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.CategoryService;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Category;

namespace PizzaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("create_new")]
        public async Task<IActionResult> SaveCategory([FromBody] CategoryDto model)
        {
            await this._categoryService.SaveCategory(model);
            return Ok("succeeded.");
        }
    }
}