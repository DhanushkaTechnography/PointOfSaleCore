using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.SubCategory;


namespace PizzaCore.Entity.Pizza
{
    public class PizzaDto
    {
        [Key]
        public int PizzaId { get; set; }
        
        public SubCategoryDto SubCategory { get; set; }

        public string PizzaName { get; set; }
        public DateTime PizzaCreateDate { get; set; }
        public DateTime PizzaUpdateDate { get; set; }
        public int PizzaStatus { get; set; }
    }
}