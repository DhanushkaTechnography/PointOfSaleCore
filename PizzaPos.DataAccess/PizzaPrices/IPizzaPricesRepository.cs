using System.Collections.Generic;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.Sizes;

namespace PizzaPos.DataAccess.PizzaPrices
{
    public interface IPizzaPricesRepository
    {
        public bool CreatePizzaPrices(PizzaSizesDto price);
        public bool UpdatePizzaPrices(PizzaSizesDto price);
        public PizzaSizesDto GetPricesBySizeAndPizza(SizesDto size,PizzaDto pizza);
        public int CountByPizza(PizzaDto dto);
        public List<PizzaSizesDto> PizzaPrices(PizzaDto dto);
        public PizzaSizesDto SearchById(int id);
    }
}