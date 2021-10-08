using System.Collections.Generic;
using PizzaCore.Entity.Sizes;

namespace PizzaCore.Business.SizesService
{
    public interface ISizesService
    {
        public bool CreateSizes(SizesDto dto);
        public List<SizesDto> GetAllSizes();
        public List<SizesDto> GetActiveSizes();
    }
}