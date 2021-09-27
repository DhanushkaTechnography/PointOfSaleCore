using PizzaPos.DataAccess.SizesRepository;

namespace PizzaCore.Business.SizesService
{
    public class SizesService: ISizesService
    {
        private readonly ISizesRepository _sizesRepository;

        public SizesService(ISizesRepository sizesRepository)
        {
            _sizesRepository = sizesRepository;
        }
    }
}