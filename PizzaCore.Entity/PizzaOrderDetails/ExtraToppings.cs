using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.ToppingPrices;

namespace PizzaCore.Entity.PizzaOrderDetails
{
    public class ExtraToppings
    {
        [Key]
        public int ExtraToppingId { get; set; }
        public PizzaOrderDetailsDto Pizza{ get; set; }
        public ToppingPricesDto Topping { get; set; }
        public string Side { get; set; }
        public int Portion { get; set; }
        public float Cost { get; set; }

        public ExtraToppings()
        {
        }

        public ExtraToppings(int extraToppingId, PizzaOrderDetailsDto pizza, ToppingPricesDto topping, string side, int portion, float cost)
        {
            ExtraToppingId = extraToppingId;
            Pizza = pizza;
            Topping = topping;
            Side = side;
            Portion = portion;
            Cost = cost;
        }
    }
}