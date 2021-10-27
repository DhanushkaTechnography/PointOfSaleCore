using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
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
            EntityEntry<CategoryDto> cate = null;
            var find =  await _dbContext.Categories.FindAsync(dto.CategoryId);
            if (find !=null)
            {
                find.Color = dto.Color;
                find.Deleted = dto.Deleted;
                find.Status = dto.Status;
                find.CategoryName = dto.CategoryName;
                find.IsOther = dto.IsOther;
                find.IsPizza = dto.IsPizza;
                find.IsTopping = dto.IsTopping;
                find.UpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                cate = _dbContext.Categories.Update(find);
            }
            else
            {
                dto.CreatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                dto.UpdatedDate = dto.CreatedDate;
                cate = _dbContext.Categories.Add(dto);
            }
            await _dbContext.SaveChangesAsync();
            return cate;
        }

        public async Task<CategoryDto> FindCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public List<CategoryDto> MainCategoryBasic()
        {
            return _dbContext.Categories.ToList();
        }

        public List<MainCategoryResponse> MainCategoryList()
        {
            List<MainCategoryResponse> list = new List<MainCategoryResponse>();
            foreach (var c in _dbContext.Categories.Where(dto => dto.Deleted != 1).ToList())
                list.Add(new MainCategoryResponse(c,_dbContext.SubCategories.Count(dto => dto.Category == c)));
            return list;
        }

        public List<CategoryDto> GetCategoriesForTopping()
        {
            return _dbContext.Categories.Where(dto => dto.IsTopping == 1 && dto.Deleted == 0).ToList();
            
        }

        public List<CategoryDto> GetPizzaCategories()
        {
            return _dbContext.Categories.Where(dto => dto.IsPizza == 1 && dto.Deleted == 0).ToList();
        }
    }
}