using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.Ingredients
{
    public class IngredientsDto
    {
        [Key]
        public int IngredientsId { get; set; }
        public PizzaDto PizzaId { get; set; }
        public ToppingsDto ToppingId { get; set; }
        public int Status { get; set; }

        public IngredientsDto()
        {
        }

        public IngredientsDto(int ingredientsId, PizzaDto pizzaId, ToppingsDto toppingId, int status)
        {
            IngredientsId = ingredientsId;
            PizzaId = pizzaId;
            ToppingId = toppingId;
            Status = status;
        }
    }
}