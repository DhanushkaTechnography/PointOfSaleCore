using System.Collections.Generic;
using PizzaCore.Entity.Sizes;
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

        public bool CreateSizes(SizesDto dto)
        {
            return _sizesRepository.SaveItemSize(dto);
        }

        public List<SizesDto> GetAllSizes()
        {
            return _sizesRepository.SizeList();
        }

        public List<SizesDto> GetActiveSizes()
        {
            return _sizesRepository.GetActiveSizes();
        }
    }
}