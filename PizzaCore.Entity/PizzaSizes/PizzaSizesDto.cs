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
        public double Price { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int Status { get; set; }

        public PizzaSizesDto()
        {
        }

        public PizzaSizesDto(int pizzaSizeId, PizzaDto pizzaId, SizesDto sizeId, double price, string createDate, string updateDate, int status)
        {
            PizzaSizeId = pizzaSizeId;
            PizzaId = pizzaId;
            SizeId = sizeId;
            Price = price;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Status = status;
        }
    }
}