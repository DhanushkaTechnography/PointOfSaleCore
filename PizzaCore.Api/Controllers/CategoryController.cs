
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.CategoryService;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Types;

namespace PizzaCore.Controllers
{
    [Route("api/category")]
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
            return Ok(true);
        }
        
        [HttpPost]
        [Route("create_new_sub_category")]
        public async Task<IActionResult> SaveSubCategory([FromBody] SubCategoryRequest model)
        {
            if (await _categoryService.SaveSubCategory(model))
                return Ok(true);
            return BadRequest();
        }
        
        [HttpPost]
        [Route("create_new_type")]
        public async Task<IActionResult> SaveNewType([FromBody] Types model)
        {
            return Ok(await _categoryService.SaveTypes(model));
        }
        
        [HttpGet]
        [Route("main_cate_basic")]
        public async Task<IActionResult> MainCategoryBasic()
        {
            return Ok(new
            {
                data = _categoryService.MainCategoryBasic()
            });
        }
        
        [HttpGet]
        [Route("main_cate_list")]
        public async Task<IActionResult> MainCategoryList()
        {
            return Ok(new
            {
                data = _categoryService.GetMainCategories()
            });
        }
        
        [HttpGet]
        [Route("sub_cate_list")]
        public async Task<IActionResult> SubCategoryList()
        {
            return Ok(new
            {
                data = _categoryService.GetSubCategoryList()
            });
        }
       
        [HttpGet]
        [Route("type_list")]
        public async Task<IActionResult> TypeList()
        {
            return Ok(new
            {
                data = _categoryService.GetTypesList()
            });
        }
        
        [HttpGet]
        [Route("topping_category_list")]
        public async Task<IActionResult> ToppingCategoryList()
        {
            return Ok(new
            {
                data = _categoryService.ForToppings()
            });
        }
        
        [HttpGet]
        [Route("pizza_category_list")]
        public async Task<IActionResult> PizzaCategoryList()
        {
            return Ok(new
            {
                data = _categoryService.GetPizzaCategoryList()
            });
        }
        
        [HttpGet]
        [Route("subs_for_main_cate")]
        public async Task<IActionResult> SubsForMain(int id)
        {
            return Ok(new
            {
                data = _categoryService.GetAllByMain(id)
            });
        }
    }
}