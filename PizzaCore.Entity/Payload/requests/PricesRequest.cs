namespace PizzaCore.Entity.Payload.requests
{
    public class PricesRequest
    {
        public int ItemId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }

        public PricesRequest()
        {
        }

        public PricesRequest(int itemId, int sizeId, double price, int status)
        {
            ItemId = itemId;
            SizeId = sizeId;
            Price = price;
            Status = status;
        }
    }
}