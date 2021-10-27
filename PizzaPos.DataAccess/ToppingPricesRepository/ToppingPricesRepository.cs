using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.ToppingPrices;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.ToppingPricesRepository
{
    public class ToppingPricesRepository : IToppingPricesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToppingPricesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ToppingPricesDto GetByToppingAndSize(ToppingsDto topping, SizesDto size)
        {
            return _dbContext.ToppingPrices.First(dto => dto.Topping == topping && dto.ToppingSize == size);
        }

        public bool SaveToppingPrices(ToppingPricesDto dto)
        {
            _dbContext.ToppingPrices.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool SaveToppingPrices(List<ToppingPricesDto> list)
        {
            _dbContext.ToppingPrices.AddRange(list);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateToppingPrices(ToppingPricesDto dto)
        {
            _dbContext.ToppingPrices.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public List<ToppingPricesDto> getAllPricesByTopping(ToppingsDto dto)
        {
            return _dbContext.ToppingPrices.Include(pricesDto => pricesDto.Topping)
                .Include(pricesDto => pricesDto.ToppingSize).Where(pricesDto => pricesDto.Topping == dto).ToList();
        }

        public List<ToppingPricesDto> GetToppingPriceBySize(SizesDto dto)
        {
            return _dbContext.ToppingPrices.Include(prices => prices.Topping).Include(prices => prices.ToppingSize)
                .Where(prices => prices.ToppingSize == dto).ToList();
        }

        public ToppingPricesDto SearchById(int id)
        {
            return _dbContext.ToppingPrices.Include(dto => dto.Topping).Include(dto => dto.ToppingSize)
                .First(dto => dto.ToppingPriceId == id);
        }
    }
}