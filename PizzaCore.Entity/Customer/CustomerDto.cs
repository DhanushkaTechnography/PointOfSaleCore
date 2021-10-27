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
        public string CusAddress { get; set; }
        public string CusCity { get; set; }
        public string CusCountry { get; set; }
        public string CusCreatedDate { get; set; }
        public string CusUpdatedDate { get; set; }
        public int CusStatus { get; set; }
    }
}