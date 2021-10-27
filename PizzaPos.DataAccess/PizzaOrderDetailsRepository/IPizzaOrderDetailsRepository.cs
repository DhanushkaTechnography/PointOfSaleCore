using PizzaCore.Entity.PizzaOrderDetails;

namespace PizzaPos.DataAccess.PizzaOrderDetailsRepository
{
    public interface IPizzaOrderDetailsRepository
    {
        public PizzaOrderDetailsDto SaveOrderDetails(PizzaOrderDetailsDto pizza);
        public bool SaveExtraTopping(ExtraToppings topping);
    }
}