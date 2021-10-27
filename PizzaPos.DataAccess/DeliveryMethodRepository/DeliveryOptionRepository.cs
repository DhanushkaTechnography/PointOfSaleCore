using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.DeliveryOptions;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.DeliveryMethodRepository
{
    public class DeliveryOptionRepository:IDeliveryOptionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliveryOptionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveOption(DeliveryOptionDto dto)
        {
            _dbContext.DeliveryOption.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateOption(DeliveryOptionDto dto)
        {
            _dbContext.DeliveryOption.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public DeliveryOptionDto FindById(int id)
        {
            return _dbContext.DeliveryOption.Find(id);
        }

        public DeliveryOptionDto FindByName(string name)
        {
            return _dbContext.DeliveryOption.First(dto => dto.MethodName == name);
        }

        public List<DeliveryOptionDto> OptionList()
        {
            return _dbContext.DeliveryOption.ToList();
        }
    }
}