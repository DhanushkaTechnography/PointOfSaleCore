using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.SubCategory;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.PizzaRepository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SavePizza(PizzaDto dto)
        {
            var entity = _dbContext.PizzaDto.Add(dto).Entity;
            _dbContext.SaveChanges();
            return entity.PizzaId;
        }

        public int UpdatePizza(PizzaDto dto)
        {
            var entity = _dbContext.PizzaDto.Update(dto).Entity;
            _dbContext.SaveChanges();
            return entity.PizzaId;
        }

        public PizzaDto SearchById(int id)
        {
            return _dbContext.PizzaDto.Include(dto => dto.SubCategory).First(dto => dto.PizzaId == id);
        }

        public List<PizzaDto> GetPizzaList()
        {
            return _dbContext.PizzaDto.Include(dto => dto.SubCategory).Where(dto => dto.Deleted != 1).ToList();
        }

        public List<PizzaDto> GetBySubcategory(SubCategoryDto sub)
        {
            return _dbContext.PizzaDto.Include(dto => dto.SubCategory)
                .Where(dto => dto.Deleted != 1 && dto.PizzaStatus == 1 && dto.SubCategory == sub).ToList();
        }
    }
}