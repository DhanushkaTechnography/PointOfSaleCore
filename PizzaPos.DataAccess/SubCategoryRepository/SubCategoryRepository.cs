using System.Threading.Tasks;
using PizzaCore.Entity.SubCategory;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.SubCategoryRepository
{
    public class SubCategoryRepository:ISubCategoryRepository

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
    }
}