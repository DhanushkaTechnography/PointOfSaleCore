using System.Collections.Generic;
using PizzaCore.Entity.Types;

namespace PizzaPos.DataAccess.TypeRepository
{
    public interface ITypeRepository
    {
        public bool SaveNewType(Types types);
        public bool UpdateType(Types types);
        public Types SearchById(int id);

        public List<Types> GetList();
    }
}