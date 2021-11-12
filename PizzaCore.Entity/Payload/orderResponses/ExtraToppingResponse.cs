namespace PizzaCore.Entity.Payload.orderResponses
{
    public class ExtraToppingResponse
    {
        public int ExtraToppingId { get; set; }
        public int OrderItemId { get; set; }
        public int ToppingPriceId { get; set; }
        public string ToppingName { get; set; }
        public string Side { get; set; }
        public int Portion { get; set; }
        public double Cost { get; set; }

        public ExtraToppingResponse()
        {
        }

        public ExtraToppingResponse(int extraToppingId, int orderItemId, int toppingPriceId,string toppingName, string side, int portion, double cost)
        {
            ExtraToppingId = extraToppingId;
            OrderItemId = orderItemId;
            ToppingPriceId = toppingPriceId;
            ToppingName = toppingName;
            Side = side;
            Portion = portion;
            Cost = cost;
        }
    }
}