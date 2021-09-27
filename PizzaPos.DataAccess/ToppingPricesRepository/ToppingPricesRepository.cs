using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ToppingPricesRepository
{
    public class ToppingPricesRepository: IToppingPricesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToppingPricesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}