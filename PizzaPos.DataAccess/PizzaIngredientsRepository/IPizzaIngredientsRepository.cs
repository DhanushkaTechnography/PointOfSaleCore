using System.Collections.Generic;
using PizzaCore.Entity.Ingredients;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.Toppings;

namespace PizzaPos.DataAccess.PizzaIngredientsRepository
{
    public interface IPizzaIngredientsRepository
    {
        public bool SavePizzaIngredient(IngredientsDto dto);
        public bool UpdatePizzaIngredient(IngredientsDto dto);
        public IngredientsDto GetByPizzaAndTopping(PizzaDto pizza,ToppingsDto topping);
        public int CountIngredient(PizzaDto dto);
        public List<IngredientsDto> GetIngredientsForPizza(PizzaDto dto);
    }
}