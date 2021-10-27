using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Order
{
    public class OrderStatusDto
    {
        [Key] public int OrderStatusId { get; set; }
        public OrderDto Order { get; set; }
        public string StatusName { get; set; }
        public string Date { get; set; }
        public int Active { get; set; }

        public OrderStatusDto()
        {
        }

        public OrderStatusDto(int orderStatusId, OrderDto order, string statusName, string date, int active)
        {
            OrderStatusId = orderStatusId;
            Order = order;
            StatusName = statusName;
            Date = date;
            Active = active;
        }
    }
}