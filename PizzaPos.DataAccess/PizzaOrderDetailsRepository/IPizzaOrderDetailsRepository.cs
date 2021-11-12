using System.Collections.Generic;
using PizzaCore.Entity.PizzaOrderDetails;

namespace PizzaPos.DataAccess.PizzaOrderDetailsRepository
{
    public interface IPizzaOrderDetailsRepository
    {
        public PizzaOrderDetailsDto SaveOrderDetails(PizzaOrderDetailsDto pizza);
        public PizzaOrderDetailsDto UpdateOrderDetails(PizzaOrderDetailsDto pizza);
        public bool SaveExtraTopping(ExtraToppings topping);
        public List<PizzaOrderDetailsDto> GetPizzaForOrder(int order);
        public List<ExtraToppings> GetToppingsForPizzaItem(int orderItem);
        public PizzaOrderDetailsDto FindById(int id);
    }
}