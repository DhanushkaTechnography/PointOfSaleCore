using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Types
{
    public class Types
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public int Status { get; set; }
        public int Deleted { get; set; }
    }
}