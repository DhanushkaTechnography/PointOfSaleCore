using System.Collections.Generic;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.SubCategory;

namespace PizzaPos.DataAccess.PizzaRepository
{
    public interface IPizzaRepository
    {
        public int SavePizza(PizzaDto dto);
        public int UpdatePizza(PizzaDto dto);
        public PizzaDto SearchById(int id);
        public List<PizzaDto> GetPizzaList();
        public List<PizzaDto> GetBySubcategory(SubCategoryDto dto);
    }
}