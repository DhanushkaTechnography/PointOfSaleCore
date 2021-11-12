using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.orderResponses
{
    public class OrdersResponse
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public int DeliveryOptionId { get; set; }
        public string CustomerName { get; set; }
        public string CashierName { get; set; }
        public string DeliveryOptionName { get; set; }
        public string DateWanted { get; set; }
        public string TimeWanted { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Note { get; set; }
        public List<string> StatusList { get; set; }
        public List<PizzaItemResponse> PizzaItems { get; set; }
        public List<OtherItemResponse> OtherItems { get; set; }

        public OrdersResponse()
        {
        }

        public OrdersResponse(int orderId, int customerId, int cashierId, int deliveryOptionId, string customerName, string cashierName, string deliveryOptionName, string dateWanted, string timeWanted, double subTotal, double discount, double tax, double total, string created, string updated, string note, List<string> statusList, List<PizzaItemResponse> pizzaItems,List<OtherItemResponse> otherItems)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CashierId = cashierId;
            DeliveryOptionId = deliveryOptionId;
            CustomerName = customerName;
            CashierName = cashierName;
            DeliveryOptionName = deliveryOptionName;
            DateWanted = dateWanted;
            TimeWanted = timeWanted;
            SubTotal = subTotal;
            Discount = discount;
            Tax = tax;
            Total = total;
            Created = created;
            Updated = updated;
            Note = note;
            StatusList = statusList;
            PizzaItems = pizzaItems;
            OtherItems = otherItems;
        }
    }
}