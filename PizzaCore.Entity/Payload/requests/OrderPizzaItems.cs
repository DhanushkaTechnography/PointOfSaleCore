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
        public int Status { get; set; }
        public List<ExtraToppingRequest> ExtraToppings;
    }
}