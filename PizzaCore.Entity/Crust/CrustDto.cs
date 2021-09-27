using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Crust
{
    public class CrustDto
    {
        [Key]
        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public DateTime CrustCreatedDate { get; set; }
        public DateTime CrustUpdatedDate { get; set; }
        public int CrustStatus { get; set; }
    }
}