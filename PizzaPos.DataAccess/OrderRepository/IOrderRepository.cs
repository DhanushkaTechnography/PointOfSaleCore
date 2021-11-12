using System.Collections.Generic;
using PizzaCore.Entity.Order;

namespace PizzaPos.DataAccess.OrderRepository
{
    public interface IOrderRepository
    {
        // ORDER
        public OrderDto SaveOrder(OrderDto order);
        public OrderDto UpdateOrder(OrderDto order);
        public OrderDto SearchOrder(int id);
        public List<OrderDto> CustomerOrders(int customerId);


        // ORDER STATUS
        public OrderStatusDto SaveOrderStatus(OrderStatusDto dto);
        public bool UpdateOrderStatus(OrderStatusDto dto);
        public OrderStatusDto SearchOrderStatus(OrderDto order);
        public List<OrderStatusDto> GetAllByStatus(string status);
        public List<OrderStatusDto> GetStatusByOrder(int orderId);
    }
}