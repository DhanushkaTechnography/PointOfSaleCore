using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.SubCategory;

namespace PizzaPos.DataAccess.SubCategoryRepository
{
    public interface ISubCategoryRepository
    {
        public Task<SubCategoryDto> SaveSubCategory(SubCategoryDto subCategoryDto);
        public SubCategoryDto GetById(int id);
        public List<SubCategoryDto> SubCategoryList();

        public Task<SubCategoryDto> UpdateSubCategory(SubCategoryDto dto);

        public List<SubCategoryDto> GetCategoryByMain(CategoryDto dto);
    }
}