using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ToppingsRepository
{
    public class ToppingsRepository: IToppingsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToppingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}