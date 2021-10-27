using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CrustPricesRepository
{
    public class CrustPricesRepository : ICrustPricesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CrustPricesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CrustPricesDto GetByCrustAndSize(CrustDto crustDto, SizesDto size)
        {
            return _dbContext.CrustPrices.First(dto => dto.Crust == crustDto && dto.CrustSize == size);
        }

        public bool SavePrice(CrustPricesDto dto)
        {
            _dbContext.CrustPrices.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdatePrice(CrustPricesDto dto)
        {
            _dbContext.CrustPrices.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public int CountByCrust(CrustDto d)
        {
            return _dbContext.CrustPrices.Count(dto => dto.Crust == d);
        }

        public List<CrustPricesDto> GetCrustPricesByCrust(CrustDto dto)
        {
            return _dbContext.CrustPrices.Include(pricesDto => pricesDto.Crust)
                .Include(pricesDto => pricesDto.CrustSize).Where(pricesDto => pricesDto.Crust == dto).ToList();
        }

        public List<CrustPricesDto> GetCrustPricesBySize(SizesDto size)
        {
            return _dbContext.CrustPrices.Include(dto => dto.Crust).Include(dto => dto.CrustSize)
                .Where(dto => dto.CrustPriceStatus == 1 && dto.CrustSize == size).ToList();
        }

        public CrustPricesDto SearchById(int id)
        {
            return _dbContext.CrustPrices.Include(dto => dto.Crust).Include(dto => dto.CrustSize)
                .First(dto => dto.CrustPriceId == id);
        }
    }
}