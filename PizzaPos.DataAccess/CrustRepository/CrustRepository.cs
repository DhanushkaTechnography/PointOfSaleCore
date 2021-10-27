using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Crust;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CrustRepository
{
    public class CrustRepository: ICrustRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CrustRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CrustDto SaveCrust(CrustDto dto)
        {
            var entity = _dbContext.Crust.Add(dto).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public CrustDto UpdateCrust(CrustDto dto)
        {
            var entry = _dbContext.Crust.Update(dto).Entity;
            _dbContext.SaveChanges();
            return entry;
        }

        public CrustDto GetById(int id)
        {
            return _dbContext.Crust.Find(id);
        }

        public List<CrustDto> GetAllCrusts()
        {
            return _dbContext.Crust.Where(dto => dto.Deleted != 1).ToList();
        }
    }
}