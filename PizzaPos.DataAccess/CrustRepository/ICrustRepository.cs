using System.Collections.Generic;
using PizzaCore.Entity.Crust;

namespace PizzaPos.DataAccess.CrustRepository
{
    public interface ICrustRepository
    {
        public CrustDto SaveCrust(CrustDto dto);
        public CrustDto UpdateCrust(CrustDto dto);
        public CrustDto GetById(int id);
        public List<CrustDto> GetAllCrusts();
    }
}