using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Category
{
    public class CategoryDto
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public int IsPizza { get; set; }
        public int IsTopping { get;set; }
        public int IsOther { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}