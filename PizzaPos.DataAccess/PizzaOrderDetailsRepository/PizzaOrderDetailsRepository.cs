using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.PizzaOrderDetailsRepository
{
    public class PizzaOrderDetailsRepository: IPizzaOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaOrderDetailsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}