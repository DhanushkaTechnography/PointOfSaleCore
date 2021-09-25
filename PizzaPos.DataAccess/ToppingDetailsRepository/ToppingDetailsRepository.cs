using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ToppingDetailsRepository
{
    public class ToppingDetailsRepository: IToppingDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToppingDetailsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}