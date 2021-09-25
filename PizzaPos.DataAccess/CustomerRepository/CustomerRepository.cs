using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CustomerRepository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}