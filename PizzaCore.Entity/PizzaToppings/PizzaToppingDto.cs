using System;
using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.PizzaOrderDetails;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.PizzaToppings
{
    public class PizzaToppingDto
    {
        [Key]
        public int PizzaToppingId { get; set; }
        
        public PizzaOrderDetailsDto PizzaOrderId { get; set; }
        public ToppingsDto ToppingId { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
    }
}