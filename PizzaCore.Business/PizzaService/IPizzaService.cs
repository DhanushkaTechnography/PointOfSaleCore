using System.Collections.Generic;
using PizzaCore.Entity.Ingredients;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Pizza;

namespace PizzaCore.Business.PizzaService
{
    public interface IPizzaService
    {
        public int SavePizza(PizzaRequest request);
        public bool SavePizzaPrices(List<PricesRequest> list);
        public bool SavePizzaIngredients(List<IngredientRequest> list);
        public List<PizzaResponse> GetPizzaList();
        public List<PizzaDto> GetPizzaByCategory(int id);
        public List<ItemPriceResponse> GetPizzaPrices(int pizzaId);
        public List<IngredientsDto> GetIngredientsForByPizza(int id);
    }
}