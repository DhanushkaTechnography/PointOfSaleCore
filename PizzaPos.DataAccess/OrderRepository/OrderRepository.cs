using System.Linq;
using PizzaCore.Entity.Order;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.OrderRepository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderDto SaveOrder(OrderDto order)
        {
            var entity = _dbContext.Orders.Add(order).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public OrderDto UpdateOrder(OrderDto order)
        {
            var entity = _dbContext.Orders.Update(order).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public OrderDto SearchOrder(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public OrderStatusDto SaveOrderStatus(OrderStatusDto dto)
        {
            var entity = _dbContext.OrderStatus.Add(dto).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool UpdateOrderStatus(OrderStatusDto dto)
        {
            var entity = _dbContext.OrderStatus.Update(dto).Entity;
            _dbContext.SaveChanges();
            return true;
        }

        public OrderStatusDto SearchOrderStatus(OrderDto order)
        {
            return _dbContext.OrderStatus.First(dto => dto.Order == order && dto.Active == 1);
        }
    }
}