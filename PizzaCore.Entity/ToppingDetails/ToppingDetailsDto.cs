using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.PizzaOrderDetails;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.PizzaOrderDetailsId
{
    public class ToppingDetailsDto
    {
        [Key]
        public int ToppingDetailsId { get; set; }
        
        public ToppingsDto Topping { get; set; }
        
        public PizzaOrderDetailsDto PizzaOrderDetails { get; set; }
        
        
        public DateTime PizzaOrderDetailsCreatedDate { get; set; }
        public DateTime PizzaOrderDetailsUpdatedDate { get; set; }
        public int PizzaOrderDetailsStatus { get; set; }
    }
}