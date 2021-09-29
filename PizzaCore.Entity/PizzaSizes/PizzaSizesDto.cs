using System;
using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.Sizes;

namespace PizzaCore.Entity.PizzaSizes
{
    public class PizzaSizesDto
    {
        [Key]
        public int PizzaSizeId{ get; set; }
        public PizzaDto PizzaId { get; set; }
        public SizesDto SizeId { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }

    }
}