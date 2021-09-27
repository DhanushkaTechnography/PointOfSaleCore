using System;
using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.Employee;

namespace PizzaCore.Entity.Order
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        
        public CustomerDto Customer { get; set; }
        
        public EmployeeDto Employee { get; set; }
        
        public float OrdSubTotal { get; set; }
        public float OrdTotal { get; set; }
        public float OrdDiscount { get; set; }
        public float OrdTax { get; set; }
        public string OrderDeliveryType { get; set; }
        public DateTime OrdCreatedDate { get; set; }
        public DateTime OrdUpdatedDate { get; set; }
        public int OrdStatus { get; set; }
    }
}