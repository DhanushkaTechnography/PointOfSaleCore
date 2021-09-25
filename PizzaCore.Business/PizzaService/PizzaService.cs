using PizzaPos.DataAccess.PizzaRepository;

namespace PizzaCore.Business.PizzaService
{
    public class PizzaService: IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
    }
}