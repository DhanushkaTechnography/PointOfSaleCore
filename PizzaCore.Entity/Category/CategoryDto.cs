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
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public int status { get; set; }
        public string CategoryType { get; set; }
    }
}