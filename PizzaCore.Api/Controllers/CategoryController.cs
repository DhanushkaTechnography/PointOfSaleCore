using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.CategoryService;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.SubCategory;

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
            await _categoryService.SaveCategory(model);
            return Ok("succeeded.");
        }
        
        [HttpPost]
        [Route("create_new_sub_category")]
        public async Task<IActionResult> SaveSubCategory([FromBody] SubCategoryRequest model)
        {
            if (await _categoryService.SaveSubCategory(model))
                return Ok("succeeded.");
            return BadRequest();
        }
    }
}