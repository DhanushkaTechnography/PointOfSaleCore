using System.Collections.Generic;
using PizzaCore.Entity.Sizes;

namespace PizzaPos.DataAccess.SizesRepository
{
    public interface ISizesRepository
    {
        public bool SaveItemSize(SizesDto dto);
        public List<SizesDto> SizeList();

        public List<SizesDto> GetActiveSizes();
    }
}