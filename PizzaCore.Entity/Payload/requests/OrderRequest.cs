using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.requests
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public int Customer { get; set; }
        public int Employee { get; set; }
        public int DeliveryOption { get; set; }
        public string DateWanted { get; set; }
        public string TimeWanted { get; set; }
        public float OrdSubTotal { get; set; }
        public float OrdDiscount { get; set; }
        public float OrdTax { get; set; }
        public float OrdTotal { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}