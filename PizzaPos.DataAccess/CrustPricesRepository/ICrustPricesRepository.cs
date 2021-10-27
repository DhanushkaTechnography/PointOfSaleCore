using System.Collections.Generic;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Sizes;

namespace PizzaPos.DataAccess.CrustPricesRepository
{
    public interface ICrustPricesRepository
    {
        public CrustPricesDto GetByCrustAndSize(CrustDto crustDto,SizesDto size);
        public bool SavePrice(CrustPricesDto dto);
        public bool UpdatePrice(CrustPricesDto dto);
        public int CountByCrust(CrustDto d);
        public List<CrustPricesDto> GetCrustPricesByCrust(CrustDto dto);
        public List<CrustPricesDto> GetCrustPricesBySize(SizesDto size);
        public CrustPricesDto SearchById(int id);
    }
}