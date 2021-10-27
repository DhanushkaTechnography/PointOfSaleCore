namespace PizzaCore.Entity.Payload.requests
{
    public class PricesRequest
    {
        public int ItemId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
    }
}