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
        public string PizzaColor { get; set; }
        public string PizzaCreateDate { get; set; }
        public string PizzaUpdateDate { get; set; }
        public int PizzaStatus { get; set; }
        public int Deleted { get; set; }

        public PizzaDto()
        {
        }

        public PizzaDto(int pizzaId, SubCategoryDto subCategory, string pizzaName, string pizzaColor,string pizzaCreateDate, string pizzaUpdateDate, int pizzaStatus, int deleted)
        {
            PizzaId = pizzaId;
            SubCategory = subCategory;
            PizzaName = pizzaName;
            PizzaColor = pizzaColor;
            PizzaCreateDate = pizzaCreateDate;
            PizzaUpdateDate = pizzaUpdateDate;
            PizzaStatus = pizzaStatus;
            Deleted = deleted;
        }
    }
}