using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Ingredients;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.Toppings;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.PizzaIngredientsRepository
{
    public class PizzaIngredientsRepository : IPizzaIngredientsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaIngredientsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SavePizzaIngredient(IngredientsDto dto)
        {
            _dbContext.Ingredients.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdatePizzaIngredient(IngredientsDto dto)
        {
            _dbContext.Ingredients.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public IngredientsDto GetByPizzaAndTopping(PizzaDto pizza, ToppingsDto topping)
        {
            return _dbContext.Ingredients.Include(dto => dto.PizzaId).Include(dto => dto.ToppingId)
                .First(dto => dto.PizzaId == pizza && dto.ToppingId == topping);
        }

        public int CountIngredient(PizzaDto dto)
        {
            return _dbContext.Ingredients.Count(ing => ing.PizzaId == dto && ing.Status != 0);
        }

        public List<IngredientsDto> GetIngredientsForPizza(PizzaDto dto)
        {
            return _dbContext.Ingredients.Include(ingredients => ingredients.PizzaId)
                .Include(ingredients => ingredients.ToppingId)
                .Where(ingredients => ingredients.PizzaId == dto && ingredients.Status == 1).ToList();
        }
    }
}