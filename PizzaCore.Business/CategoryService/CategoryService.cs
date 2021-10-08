using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.SubCategory;
using PizzaCore.Entity.Types;
using PizzaPos.DataAccess.CategoryRepository;
using PizzaPos.DataAccess.SubCategoryRepository;
using PizzaPos.DataAccess.TypeRepository;

namespace PizzaCore.Business.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITypeRepository _typeRepository;

        public CategoryService(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository,
            ITypeRepository typeRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _typeRepository = typeRepository;
        }

        public async Task<bool> SaveCategory(CategoryDto dto)
        {
            return await _categoryRepository.SaveCategory(dto) != null;
        }

        public async Task<bool> SaveSubCategory(SubCategoryRequest dto)
        {
            var byId = _subCategoryRepository.GetById(dto.SubCategoryId);
            if (byId == null)
            {
                byId = new SubCategoryDto(dto.SubCategoryId, _typeRepository.SearchById(dto.Type),
                    _categoryRepository.FindCategoryById(dto.Category).Result,
                    dto.SubCatName, dto.SubCatStatus, dto.Deleted);
                byId.SubCatCreatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                byId.SubCatUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                return _subCategoryRepository.SaveSubCategory(byId).Result != null;
            }

            byId.Category = _categoryRepository.FindCategoryById(dto.Category).Result;
            byId.Deleted = dto.Deleted;
            byId.Type = _typeRepository.SearchById(dto.Type);
            byId.SubCatName = dto.SubCatName;
            byId.SubCatStatus = dto.SubCatStatus;
            byId.SubCatUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            return _subCategoryRepository.UpdateSubCategory(byId).Result != null;
        }

        public async Task<bool> SaveTypes(Types type)
        {
            var byId = _typeRepository.SearchById(type.TypeId);
            if (byId == null)
            {
                type.CreatedAt = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                type.UpdatedAt = type.CreatedAt;
                return _typeRepository.SaveNewType(type);
            }

            byId.Deleted = type.Deleted;
            byId.Status = type.Status;
            byId.TypeName = type.TypeName;
            byId.UpdatedAt = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            return _typeRepository.UpdateType(byId);
        }

        public List<BasicResponse> MainCategoryBasic()
        {
            List<BasicResponse> list = new List<BasicResponse>();
            foreach (var dto in _categoryRepository.MainCategoryBasic())
            {
                list.Add(new BasicResponse(dto.CategoryId, dto.CategoryName));
            }

            return list;
        }

        public List<MainCategoryResponse> GetMainCategories()
        {
            return _categoryRepository.MainCategoryList();
        }

        public List<Types> GetTypesList()
        {
            return _typeRepository.GetList();
        }

        public List<SubCategoryResponse> GetSubCategoryList()
        {
            List<SubCategoryResponse> list = new List<SubCategoryResponse>();
            foreach (var subCategoryDto in _subCategoryRepository.SubCategoryList())
                list.Add(new SubCategoryResponse(subCategoryDto.SubCategoryId, subCategoryDto.Type.TypeId,
                    subCategoryDto.Type.TypeName, subCategoryDto.Category.CategoryId,
                    subCategoryDto.Category.CategoryName, subCategoryDto.SubCatName, subCategoryDto.SubCatCreatedDate,
                    subCategoryDto.SubCatUpdatedDate, subCategoryDto.SubCatStatus, subCategoryDto.Deleted));
            return list;
        }

        public List<SubCategoryResponse> ForToppings()
        {
            List<SubCategoryResponse> list = new List<SubCategoryResponse>();
            foreach (var main in _categoryRepository.GetCategoriesForTopping())
            {
                foreach (var sub in _subCategoryRepository.GetCategoryByMain(main))
                {
                    list.Add(new SubCategoryResponse(sub.SubCategoryId,sub.Type.TypeId,
                        sub.Type.TypeName,sub.Category.CategoryId,sub.Category.CategoryName,
                        sub.SubCatName,sub.SubCatCreatedDate,sub.SubCatUpdatedDate,sub.SubCatStatus,
                        sub.Deleted));
                }
            }

            return list;
        }
    }
}