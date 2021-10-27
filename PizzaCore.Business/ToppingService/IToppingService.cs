using System.Collections.Generic;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.ToppingPrices;

namespace PizzaCore.Business.ToppingService
{
    public interface IToppingService
    {
        public int SaveTopping(ToppingRequest request);
        public bool SaveToppingPrices(List<PricesRequest> list);
        public List<ToppingResponse> GetAllToppings();
        public List<ToppingPricesDto> GetPricesByTopping(int id);
        public List<ItemPriceResponse> GetPricesBySize(int id);
    }
}