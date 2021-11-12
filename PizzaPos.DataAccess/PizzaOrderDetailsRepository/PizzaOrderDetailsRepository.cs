using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public PizzaOrderDetailsDto UpdateOrderDetails(PizzaOrderDetailsDto pizza)
        {
            var entry = _dbContext.OrderDetailsPizza.Update(pizza);
            _dbContext.SaveChanges();
            return entry.Entity;
        }

        public bool SaveExtraTopping(ExtraToppings topping)
        {
            _dbContext.ExtraTopping.Add(topping);
            _dbContext.SaveChanges();
            return true;
        }

        public List<PizzaOrderDetailsDto> GetPizzaForOrder(int order)
        {
            return _dbContext.OrderDetailsPizza.Include(dto => dto.Crust).Include(dto => dto.Order)
                .Include(dto => dto.Pizza).Where(dto => dto.Order.OrderId == order).ToList();
        }

        public List<ExtraToppings> GetToppingsForPizzaItem(int orderItem)
        {
            return _dbContext.ExtraTopping.Include(toppings => toppings.Pizza).Include(toppings => toppings.Topping)
                .Where(toppings => toppings.Pizza.PizzaOrderDetailsId == orderItem).ToList();
        }

        public PizzaOrderDetailsDto FindById(int id)
        {
            return _dbContext.OrderDetailsPizza.Include(dto => dto.Crust).Include(dto => dto.Pizza)
                .Include(dto => dto.Order).First(dto => dto.PizzaOrderDetailsId == id);
        }
    }
}