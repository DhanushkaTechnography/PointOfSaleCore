using PizzaCore.Entity.PizzaOrderDetails;
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

        public PizzaOrderDetailsDto SaveOrderDetails(PizzaOrderDetailsDto pizza)
        {
            var entry = _dbContext.OrderDetailsPizza.Add(pizza);
            _dbContext.SaveChanges();
            return entry.Entity;
        }

        public bool SaveExtraTopping(ExtraToppings topping)
        {
            _dbContext.ExtraTopping.Add(topping);
            _dbContext.SaveChanges();
            return true;
        }
    }
}