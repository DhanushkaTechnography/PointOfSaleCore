using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.OrderRepository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}