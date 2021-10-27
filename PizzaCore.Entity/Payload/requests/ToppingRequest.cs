using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.requests
{
    public class ToppingRequest
    {
        public int ToppingsId { get; set; }
        public int Category { get; set; }
        public string ToppingName { get; set; }
        public int ToppingStatus { get; set; }
        public int Deleted { get; set; }
        
    }
}