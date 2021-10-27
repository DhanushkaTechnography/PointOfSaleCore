namespace PizzaCore.Entity.Payload.requests
{
    public class ExtraToppingRequest
    {
        public int ExtraToppingId { get; set; }
        public int ToppingPriceId { get; set; }
        public string Side { get; set; }
        public int Portion { get; set; }
        public float Cost { get; set; }
    }
}