using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.Sizes;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.PizzaPrices
{
    public class PizzaPricesRepository : IPizzaPricesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaPricesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreatePizzaPrices(PizzaSizesDto price)
        {
            _dbContext.PizzaPrice.Add(price);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdatePizzaPrices(PizzaSizesDto price)
        {
            _dbContext.PizzaPrice.Update(price);
            _dbContext.SaveChanges();
            return true;
        }

        public PizzaSizesDto GetPricesBySizeAndPizza(SizesDto size, PizzaDto pizza)
        {
            return _dbContext.PizzaPrice.Include(dto => dto.PizzaId).Include(dto => dto.SizeId)
                .First(dto => dto.PizzaId == pizza && dto.SizeId == size);
        }

        public int CountByPizza(PizzaDto dto)
        {
            return _dbContext.PizzaPrice.Count(sizes => sizes.PizzaId == dto && sizes.Status != 0);
        }

        public List<PizzaSizesDto> PizzaPrices(PizzaDto dto)
        {
            return _dbContext.PizzaPrice.Include(price => price.PizzaId).Include(price => price.SizeId).Where(price => price.PizzaId == dto && price.Status == 1).ToList();
        }

        public PizzaSizesDto SearchById(int id)
        {
            return _dbContext.PizzaPrice.Include(dto => dto.PizzaId).Include(dto => dto.SizeId)
                .First(dto => dto.PizzaSizeId == id);
        }
    }
}