using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaCore.Entity.Category;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntityEntry<CategoryDto>> SaveCategory(CategoryDto dto)
        {
            var cate = await _dbContext.Categories.AddAsync(dto);
            await _dbContext.SaveChangesAsync();
            return cate;
        }

        public async Task<CategoryDto> FindCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }
    }
}