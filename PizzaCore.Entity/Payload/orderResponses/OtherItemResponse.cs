namespace PizzaCore.Entity.Payload.orderResponses
{
    public class OtherItemResponse
    {
        public int OrderDetailsId { get; set; }
        public int ItemPriceId { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public string Varient { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public int Status { get; set; }

        public OtherItemResponse()
        {
        }

        public OtherItemResponse(int orderDetailsId, int itemPriceId, int orderId, int categoryId, string itemName, string categoryName,string color, string varient, int qty, double price, double subTotal, int status)
        {
            OrderDetailsId = orderDetailsId;
            ItemPriceId = itemPriceId;
            OrderId = orderId;
            CategoryId = categoryId;
            ItemName = itemName;
            CategoryName = categoryName;
            Color = color;
            Varient = varient;
            Qty = qty;
            Price = price;
            SubTotal = subTotal;
            Status = status;
        }
    }
}