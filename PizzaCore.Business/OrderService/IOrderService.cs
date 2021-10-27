using System.Collections.Generic;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.Payload.requests;
using PizzaCore.Entity.PizzaOrderDetails;

namespace PizzaCore.Business.OrderService
{
    public interface IOrderService
    {
        // DELIVERY OPTIONS
        public bool SaveDeliveryOption(DeliveryOptionDto dto);
        public List<DeliveryOptionDto> GetDeliveryOptions();
        
        // ORDERS
        public int SaveOrder(OrderRequest dto);
        public bool SaveOrderPizzaItems(List<OrderPizzaItems> pizzaItems,OrderDto order);
        public bool SaveExtraToppings(List<ExtraToppingRequest> toppings,PizzaOrderDetailsDto dto);
        
        // ORDER STATUS
        public bool SaveOrderStatus(int order, string status);
    }
}