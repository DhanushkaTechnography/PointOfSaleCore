using System.Collections.Generic;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Business.CrustService
{
    public interface ICrustService
    {
        public int SaveCrust(CrustDto dto);
        public bool SaveCrustPrices(List<PricesRequest> list);
        public List<CrustResponse> GetAllCrusts();
        public List<CrustPricesDto> GetPricesForCrust(int id);
        public List<ItemPriceResponse> GetCrustPricesForSize(int size);
    }
}