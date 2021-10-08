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
        public Types.Types Type { get; set; }
        public CategoryDto Category { get; set; }
        public string SubCatName { get; set; }
        
        public string SubCatCreatedDate { get; set; }
        public string SubCatUpdatedDate { get; set; }
        public int SubCatStatus { get; set; }
        public int Deleted { get; set; }
        
        public SubCategoryDto()
        {
                
        }

        public SubCategoryDto(int subCategoryId, Types.Types type, CategoryDto category, string subCatName, int subCatStatus,int deleted)
        {
            SubCategoryId = subCategoryId;
            Type = type;
            Category = category;
            SubCatName = subCatName;
            SubCatStatus = subCatStatus;
            Deleted = deleted;
        }
    }
}