using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.requests
{
    public class OrderPizzaItems
    {
        public int PizzaOrderDetailsId { get; set; }
        public int Pizza { get; set; }
        public int Crust { get; set; }
        public float PizzaSubTotal { get; set; }
        public string Note { get; set; }
        public int Qty { get; set; }
        public int Status { get; set; }
        public List<ExtraToppingRequest> ExtraToppings { get; set; }

    public OrderPizzaItems()
        {
        }

        public OrderPizzaItems(List<ExtraToppingRequest> extraToppings, int pizzaOrderDetailsId, int pizza, int crust, float pizzaSubTotal, string note, int qty,int status)
        {
            ExtraToppings = extraToppings;
            PizzaOrderDetailsId = pizzaOrderDetailsId;
            Pizza = pizza;
            Crust = crust;
            PizzaSubTotal = pizzaSubTotal;
            Note = note;
            Qty = qty;
            Status = status;
        }
    }
}