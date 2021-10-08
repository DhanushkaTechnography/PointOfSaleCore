using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.SubCategory;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.SubCategoryRepository
{
    public class SubCategoryRepository : ISubCategoryRepository

    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryRepository(ApplicationDbContext dbContext)
        {
            dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            _dbContext = dbContext;
        }

        public async Task<SubCategoryDto> SaveSubCategory(SubCategoryDto subCategoryDto)
        {
            var entity = _dbContext.SubCategories.AddAsync(subCategoryDto).Result.Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public SubCategoryDto GetById(int id)
        {
            return _dbContext.SubCategories.Find(id);
        }

        public List<SubCategoryDto> SubCategoryList()
        {
            return _dbContext.SubCategories.Include(dto => dto.Category)
                .Include(dto => dto.Type)
                .Where(dto => dto.Deleted != 1).ToList();
        }

        public async Task<SubCategoryDto> UpdateSubCategory(SubCategoryDto dto)
        {
            var entity = _dbContext.SubCategories.Update(dto).Entity;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public List<SubCategoryDto> GetCategoryByMain(CategoryDto dto)
        {
            return _dbContext.SubCategories.Include(c => c.Category)
                .Include(t => t.Type).Where(categoryDto => categoryDto.Category == dto && categoryDto.Deleted == 0).ToList();
        }
    }
}