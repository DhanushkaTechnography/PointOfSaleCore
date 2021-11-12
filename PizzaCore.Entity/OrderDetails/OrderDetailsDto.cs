using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Item;
using PizzaCore.Entity.Order;

namespace PizzaCore.Entity.OrderDetails
{
    public class OrderDetailsDto
    {
        [Key]
        public int DetailsId { get; set; }
        public OrderDto Order { get; set; }
        public ItemDetails Item { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public int Status { get; set; }
    }
}