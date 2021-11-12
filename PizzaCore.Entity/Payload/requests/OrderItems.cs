namespace PizzaCore.Entity.Payload.requests
{
    public class OrderItems
    {
        public int DetailsId { get; set; }
        public int Order { get; set; }
        public int Item { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public int Status { get; set; }

        public OrderItems()
        {
        }

        public OrderItems(int detailsId, int order, int item, int qty, double price, double subTotal, int status)
        {
            DetailsId = detailsId;
            Order = order;
            Item = item;
            Qty = qty;
            Price = price;
            SubTotal = subTotal;
            Status = status;
        }
    }
}