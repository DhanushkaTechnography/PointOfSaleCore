using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.SubCategory;

namespace PizzaCore.Entity.Toppings
{
    public class ToppingsDto
    {
        [Key]
        public int ToppingsId { get; set; }
        public string ToppingName { get; set; }
        public SubCategoryDto Category { get; set; }
        public string ToppingCreatedDate { get; set; }
        public string ToppingUpdatedDate { get; set; }
        public int ToppingStatus { get; set; }
        public int Deleted { get; set; }

        public ToppingsDto()
        {
        }

        public ToppingsDto(int toppingsId, string toppingName,SubCategoryDto category, string toppingCreatedDate, string toppingUpdatedDate, int toppingStatus,int deleted)
        {
            ToppingsId = toppingsId;
            ToppingName = toppingName;
            Category = category;
            ToppingCreatedDate = toppingCreatedDate;
            ToppingUpdatedDate = toppingUpdatedDate;
            ToppingStatus = toppingStatus;
            Deleted = deleted;
        }
    }
}