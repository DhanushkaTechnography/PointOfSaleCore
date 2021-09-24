using System;
using System.Threading.Tasks;
using PizzaCore.Entity.Category;
using PizzaPos.DataAccess.CategoryRepository;

namespace PizzaCore.Business.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> SaveCategory(CategoryDto dto)
        {
            var task = await _categoryRepository.SaveCategory(dto);
            Console.WriteLine(task.Entity.CategoryName);
            return true;
        }
    }
}