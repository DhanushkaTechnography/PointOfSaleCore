using System;
using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.DeliveryOptions;
using PizzaCore.Entity.Employee;

namespace PizzaCore.Entity.Order
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        public CustomerDto Customer { get; set; }
        public AuthenticationDto.Employee Employee { get; set; }
        public DeliveryOptionDto DeliveryOption { get; set; }
        public string DateWanted { get; set; }
        public string TimeWanted { get; set; }
        public float OrdSubTotal { get; set; }
        public float OrdDiscount { get; set; }
        public float OrdTax { get; set; }
        public float OrdTotal { get; set; }
        public string OrdCreatedDate { get; set; }
        public string OrdUpdatedDate { get; set; }
        public string Note { get; set; }
        public string PayBy { get; set; }

        public OrderDto()
        {
        }

        public OrderDto(int orderId, CustomerDto customer, AuthenticationDto.Employee employee, DeliveryOptionDto deliveryOption, string dateWanted, string timeWanted, float ordSubTotal, float ordDiscount, float ordTax, float ordTotal, string ordCreatedDate, string ordUpdatedDate,string note,string payBy)
        {
            OrderId = orderId;
            Customer = customer;
            Employee = employee;
            DeliveryOption = deliveryOption;
            DateWanted = dateWanted;
            TimeWanted = timeWanted;
            OrdSubTotal = ordSubTotal;
            OrdDiscount = ordDiscount;
            OrdTax = ordTax;
            OrdTotal = ordTotal;
            OrdCreatedDate = ordCreatedDate;
            OrdUpdatedDate = ordUpdatedDate;
            Note = note;
            PayBy = payBy;
        }
        public void UpdateData(CustomerDto customer, AuthenticationDto.Employee employee, DeliveryOptionDto deliveryOption, string dateWanted, string timeWanted, float ordSubTotal, float ordDiscount, float ordTax, float ordTotal,string ordUpdatedDate,string note,string payBy)
        {
            Customer = customer;
            Employee = employee;
            DeliveryOption = deliveryOption;
            DateWanted = dateWanted;
            TimeWanted = timeWanted;
            OrdSubTotal = ordSubTotal;
            OrdDiscount = ordDiscount;
            OrdTax = ordTax;
            OrdTotal = ordTotal;
            OrdUpdatedDate = ordUpdatedDate;
            Note = note;
            PayBy = payBy;
        }
    }
}