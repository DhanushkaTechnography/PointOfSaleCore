using System.Threading.Tasks;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.SubCategory;

namespace PizzaCore.Business.CategoryService
{
    public interface ICategoryService
    {
        public Task<bool> SaveCategory(CategoryDto dto);
        public Task<bool> SaveSubCategory(SubCategoryRequest dto);
    }
}