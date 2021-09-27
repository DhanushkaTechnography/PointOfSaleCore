using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.EmployeeRepository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}