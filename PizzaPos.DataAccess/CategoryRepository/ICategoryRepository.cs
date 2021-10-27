using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;

namespace PizzaPos.DataAccess.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<EntityEntry<CategoryDto>> SaveCategory(CategoryDto dto);
        public Task<CategoryDto> FindCategoryById(int id);
        public List<CategoryDto> MainCategoryBasic();
        public List<MainCategoryResponse> MainCategoryList();
        public List<CategoryDto> GetCategoriesForTopping();
        public List<CategoryDto> GetPizzaCategories();
    }
}