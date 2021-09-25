using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CrustRepository
{
    public class CrustRepository: ICrustRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CrustRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}