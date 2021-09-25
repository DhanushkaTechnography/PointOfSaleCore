using System;
using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Customer;

namespace PizzaCore.Entity.Order
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        public CustomerDto CusId { get; set; }
        public int EmpId { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Discount { get; set; }
        public float Tax { get; set; }
        public string OrderDeliveryType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}