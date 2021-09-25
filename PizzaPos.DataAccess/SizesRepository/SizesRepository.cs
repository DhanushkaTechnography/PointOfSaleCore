using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.SizesRepository
{
    public class SizesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SizesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}