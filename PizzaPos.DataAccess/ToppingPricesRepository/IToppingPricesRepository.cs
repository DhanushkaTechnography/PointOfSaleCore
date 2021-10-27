using System.Collections.Generic;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.ToppingPrices;
using PizzaCore.Entity.Toppings;

namespace PizzaPos.DataAccess.ToppingPricesRepository
{
    public interface IToppingPricesRepository
    {
        public ToppingPricesDto GetByToppingAndSize(ToppingsDto topping, SizesDto size);
        public bool SaveToppingPrices(ToppingPricesDto dto);
        public bool SaveToppingPrices(List<ToppingPricesDto> list);
        public bool UpdateToppingPrices(ToppingPricesDto dto);
        public List<ToppingPricesDto> getAllPricesByTopping(ToppingsDto dto);
        public List<ToppingPricesDto> GetToppingPriceBySize(SizesDto dto);
        public ToppingPricesDto SearchById(int id);
    }
}