using PizzaCore.Entity.Order;

namespace PizzaPos.DataAccess.OrderRepository
{
    public interface IOrderRepository
    {
        // ORDER
        public OrderDto SaveOrder(OrderDto order);
        public OrderDto UpdateOrder(OrderDto order);
        public OrderDto SearchOrder(int id);
        
        // ORDER STATUS
        public OrderStatusDto SaveOrderStatus(OrderStatusDto dto);
        public bool UpdateOrderStatus(OrderStatusDto dto);
        public OrderStatusDto SearchOrderStatus(OrderDto order);
    }
}