using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Crust
{
    public class CrustDto
    {
        [Key]
        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}