namespace PizzaCore.Entity.Payload.orderResponses
{
    public class CustomerOrdersResponse
    {
        public int OrderId { get; set; }
        public string Cashier { get; set; }
        public string DeliveryOption { get; set; }
        public string RequestedDate { get; set; }
        public string CreatedDate { get; set; }
        public double Total { get; set; }

        public CustomerOrdersResponse()
        {
        }

        public CustomerOrdersResponse(int orderId, string cashier, string deliveryOption, string requestedDate, string createdDate, double total)
        {
            OrderId = orderId;
            Cashier = cashier;
            DeliveryOption = deliveryOption;
            RequestedDate = requestedDate;
            CreatedDate = createdDate;
            Total = total;
        }
    }
}