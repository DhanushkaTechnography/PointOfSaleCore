using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features.Authentication;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.SubCategory;
using PizzaCore.Entity.Types;

namespace PizzaCore.Business.CategoryService
{
    public interface ICategoryService
    {
        public Task<bool> SaveCategory(CategoryDto dto);
        public Task<bool> SaveSubCategory(SubCategoryRequest dto);
        public Task<bool> SaveTypes(Types type);
        public List<BasicResponse> MainCategoryBasic();
        public List<MainCategoryResponse> GetMainCategories();
        public List<Types> GetTypesList();
        public List<SubCategoryResponse> GetSubCategoryList();
        public List<SubCategoryResponse> ForToppings();
        public List<CategoryDto> GetPizzaCategoryList();
        public List<SubCategoryResponse> GetAllByMain(int cate);
    }
}