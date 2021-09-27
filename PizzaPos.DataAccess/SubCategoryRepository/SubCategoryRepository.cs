using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.SubCategoryRepository
{
    public class SubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}