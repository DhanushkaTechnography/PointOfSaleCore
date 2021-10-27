using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ToppingsRepository
{
    public class ToppingsRepository: IToppingsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToppingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ToppingsDto SaveTopping(ToppingsDto dto)
        {
            var entity = _dbContext.Toppings.Add(dto).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public ToppingsDto UpdateTopping(ToppingsDto dto)
        {
            var entity = _dbContext.Toppings.Update(dto).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public ToppingsDto GetToppingById(int toppingsId)
        {
            return _dbContext.Toppings.Find(toppingsId);
        }

        public List<ToppingsDto> GetAllToppings()
        {
            return _dbContext.Toppings.Include(dto => dto.Category).ToList();
        }
    }
}