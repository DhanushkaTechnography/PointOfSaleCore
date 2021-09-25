using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Category;

namespace PizzaCore.Entity.SubCategory
{
    public class SubCategoryDto
    {
        [Key]
        public int SubCategoryId { get; set; }
        
        public CategoryDto Category { get; set; }

        public string SubCatName { get; set; }
        public DateTime SubCatCreatedDate { get; set; }
        public DateTime SubCatUpdatedDate { get; set; }
        public int SubCatStatus { get; set; }
        

    }
}