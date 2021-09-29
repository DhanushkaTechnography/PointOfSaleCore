using System;
using System.Threading.Tasks;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.SubCategory;
using PizzaPos.DataAccess.CategoryRepository;
using PizzaPos.DataAccess.SubCategoryRepository;

namespace PizzaCore.Business.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<bool> SaveCategory(CategoryDto dto)
        {
            return await _categoryRepository.SaveCategory(dto) !=null;
        }

        public async Task<bool> SaveSubCategory(SubCategoryRequest dto)
        {
            return _subCategoryRepository.SaveSubCategory
                (new SubCategoryDto(dto.SubCategoryId,_categoryRepository.FindCategoryById(dto.Category).Result
                    ,dto.SubCatName,dto.SubCatStatus)).Result != null;
        }
    }
}