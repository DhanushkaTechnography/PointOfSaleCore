using System.Collections.Generic;
using PizzaCore.Entity.Toppings;

namespace PizzaPos.DataAccess.ToppingsRepository
{
    public interface IToppingsRepository
    {
        public ToppingsDto SaveTopping(ToppingsDto dto);
        public ToppingsDto UpdateTopping(ToppingsDto dto);
        public ToppingsDto GetToppingById(int ToppingsId);

        public List<ToppingsDto> GetAllToppings();
        int GetToppingTypeById(int toppingToppingsId);
    }
}