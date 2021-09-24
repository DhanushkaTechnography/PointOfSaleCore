using System.Threading.Tasks;
using PizzaCore.Entity.Category;

namespace PizzaCore.Business.CategoryService
{
    public interface ICategoryService
    {
        public Task<bool> SaveCategory(CategoryDto dto);
    }
}