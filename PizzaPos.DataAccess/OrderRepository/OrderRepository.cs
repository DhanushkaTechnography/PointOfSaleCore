using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<OrderDto> CustomerOrders(int customerId)
        {
            return _dbContext.Orders.Include(dto => dto.Customer).Include(dto => dto.Employee)
                .Include(dto => dto.DeliveryOption).Where(dto => dto.Customer.CusId == customerId).ToList();
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

        public List<OrderStatusDto> GetAllByStatus(string status)
        {
            return _dbContext.OrderStatus.Include(dto => dto.Order).Include(dto => 
                dto.Order.Customer).Include(dto => 
                dto.Order.Employee).Include(dto => 
                dto.Order.DeliveryOption).Where(dto => dto.StatusName == status && dto.Active == 1).ToList();
        }

        public List<OrderStatusDto> GetStatusByOrder(int orderId)
        {
            return _dbContext.OrderStatus.Where(dto => dto.Order.OrderId == orderId).ToList();
        }
    }
}