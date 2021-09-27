using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.PizzaRepository
{
    public class PizzaRepository: IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}