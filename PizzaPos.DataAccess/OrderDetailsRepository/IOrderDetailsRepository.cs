using System.Collections.Generic;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.OrderDetails;

namespace PizzaPos.DataAccess.OrderDetailsRepository
{
    public interface IOrderDetailsRepository
    {
        bool SaveOrderDetail(OrderDetailsDto detailsDto);
        bool UpdateOrderDetail(OrderDetailsDto detailsDto);
        List<OrderDetailsDto> FindAllByOrder(OrderDto order);
        OrderDetailsDto FindById(int id);
    }
}