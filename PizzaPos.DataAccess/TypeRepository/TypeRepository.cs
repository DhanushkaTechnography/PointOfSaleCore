using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Types;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.TypeRepository
{
    public class TypeRepository:ITypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveNewType(Types types)
        {
            var b = _dbContext.Types.Add(types).Entity!=null;
            _dbContext.SaveChanges();
            return b;
        }

        public bool UpdateType(Types types)
        {
            var b = _dbContext.Types.Update(types).Entity!=null;
            _dbContext.SaveChanges();
            return b;
        }

        public Types SearchById(int id)
        {
            return _dbContext.Types.Find(id);
        }

        public List<Types> GetList()
        {
            return _dbContext.Types.Where(types => types.Deleted != 1).ToList();
        }
    }
}