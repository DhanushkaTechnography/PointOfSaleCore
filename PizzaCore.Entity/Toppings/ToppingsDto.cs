using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Category;

namespace PizzaCore.Entity.Toppings
{
    public class ToppingsDto
    {
        [Key]
        public int ToppingsId { get; set; }
        
        public string ToppingName { get; set; }
        public DateTime ToppingCreatedDate { get; set; }
        public DateTime ToppingUpdatedDate { get; set; }
        public int ToppingStatus { get; set; }
    }
}