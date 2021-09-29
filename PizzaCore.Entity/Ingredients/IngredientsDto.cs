using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.Pizza;

namespace PizzaCore.Entity.Ingredients
{
    public class IngredientsDto
    {
        [Key]
        public int IngredientsId { get; set; }
        
        public PizzaDto PizzaId { get; set; }
        public CrustDto CrustId { get; set; }
        public int Status { get; set; }
    }
}