using PizzaPos.DataAccess.ToppingsRepository;

namespace PizzaCore.Business.ToppingService
{
    public class ToppingService: IToppingService
    {
        private readonly IToppingsRepository _toppingsRepository;

        public ToppingService(IToppingsRepository toppingsRepository)
        {
            _toppingsRepository = toppingsRepository;
        }
    }
}