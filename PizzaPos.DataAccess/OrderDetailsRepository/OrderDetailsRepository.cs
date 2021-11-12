using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.OrderDetails;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.OrderDetailsRepository
{
    public class OrderDetailsRepository:IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetailsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveOrderDetail(OrderDetailsDto detailsDto)
        {
            _dbContext.OrderDetails.Add(detailsDto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateOrderDetail(OrderDetailsDto detailsDto)
        {
            _dbContext.OrderDetails.Update(detailsDto);
            _dbContext.SaveChanges();
            return true;
        }

        public List<OrderDetailsDto> FindAllByOrder(OrderDto order)
        {
            return _dbContext.OrderDetails.Include(dto => dto.Item).Include(dto => dto.Order)
                .Where(dto => dto.Order.OrderId == order.OrderId).ToList();
        }

        public OrderDetailsDto FindById(int id)
        {
            return _dbContext.OrderDetails.Include(dto => dto.Order).Include(dto => dto.Item)
                .First(dto => dto.DetailsId == id);
        }
    }
}