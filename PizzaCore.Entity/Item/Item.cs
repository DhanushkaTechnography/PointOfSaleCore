using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Category;

namespace PizzaCore.Entity.Item
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public CategoryDto Category { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Item()
        {
        }

        public Item(int itemId, CategoryDto category, string name, int status)
        {
            ItemId = itemId;
            Category = category;
            Name = name;
            Status = status;
        }
    }
}