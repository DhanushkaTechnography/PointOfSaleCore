using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Category
{
    public class CategoryDto
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string IsPizzaCategory { get; set; }
        public string IsToppingCategory { get; set; }
        public string IsOtherItemCategory { get; set; }
    }
}