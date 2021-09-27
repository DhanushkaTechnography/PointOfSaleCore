using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CrustPricesRepository
{
    public class CrustPricesRepository: ICrustPricesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CrustPricesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}