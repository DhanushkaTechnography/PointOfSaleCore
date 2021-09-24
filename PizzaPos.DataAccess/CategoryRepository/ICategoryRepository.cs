using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaCore.Entity.Category;

namespace PizzaPos.DataAccess.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<EntityEntry<CategoryDto>> SaveCategory(CategoryDto dto);
    }
}