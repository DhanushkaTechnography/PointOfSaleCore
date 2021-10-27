using System.Collections.Generic;
using PizzaCore.Entity.DeliveryOptions;

namespace PizzaPos.DataAccess.DeliveryMethodRepository
{
    public interface IDeliveryOptionRepository
    {
        public bool SaveOption(DeliveryOptionDto dto);
        public bool UpdateOption(DeliveryOptionDto dto);
        public DeliveryOptionDto FindById(int id);
        public DeliveryOptionDto FindByName(string name);
        public List<DeliveryOptionDto> OptionList();
    }
}