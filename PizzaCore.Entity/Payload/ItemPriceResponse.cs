namespace PizzaCore.Entity.Payload
{
    public class ItemPriceResponse
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
        public int SizeId { get; set; }
        public string ItemName { get; set; }
        public string SizeName { get; set; }
        public double Price { get; set; }

        public ItemPriceResponse()
        {
        }

        public ItemPriceResponse(int priceId, int itemId, int sizeId, string itemName, string sizeName, double price)
        {
            PriceId = priceId;
            ItemId = itemId;
            SizeId = sizeId;
            ItemName = itemName;
            SizeName = sizeName;
            Price = price;
        }
    }
}