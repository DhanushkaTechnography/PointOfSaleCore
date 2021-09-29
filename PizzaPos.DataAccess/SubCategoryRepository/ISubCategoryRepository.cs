using System.Threading.Tasks;
using PizzaCore.Entity.SubCategory;

namespace PizzaPos.DataAccess.SubCategoryRepository
{
    public interface ISubCategoryRepository
    {
        public Task<SubCategoryDto> SaveSubCategory(SubCategoryDto subCategoryDto);
    }
}