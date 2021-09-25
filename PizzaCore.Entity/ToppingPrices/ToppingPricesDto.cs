using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.ToppingPrices
{
    public class ToppingPricesDto
    {
        [Key]
        public int ToppingPriceId { get; set; }
        
        public ToppingsDto Topping { get; set; }
        
        public SizesDto ToppingSize { get; set; }
        
        public double ToppingPrice { get; set; }
        public DateTime ToppingPriceCreatedDate { get; set; }
        public DateTime ToppingPriceUpdatedDate { get; set; }
        public int ToppingPriceStatus { get; set; }
    }
}