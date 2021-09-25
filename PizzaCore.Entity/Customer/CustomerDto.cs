using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Customer
{
    public class CustomerDto
    {
        [Key]
        public int CusId { get; set; }
        public string CusName { get; set; }
        public string CusContact { get; set; }
        public string CusStreet { get; set; }
        public string CusCity { get; set; }
        public string CusCountry { get; set; }
        public string CusEmail { get; set; }
        public string CusType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}