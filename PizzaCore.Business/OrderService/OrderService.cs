using PizzaPos.DataAccess.OrderRepository;

namespace PizzaCore.Business.OrderService
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}