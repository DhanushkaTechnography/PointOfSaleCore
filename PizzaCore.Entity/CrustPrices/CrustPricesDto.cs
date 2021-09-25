using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.CrustPrices
{
    public class CrustPricesDto_
    {
        [Key]
        public int CrustPriceId { get; set; }
        
        public CrustDto Crust { get; set; }
        
        public SizesDto CrustSize { get; set; }

        public double CrustPrice { get; set; }
        public DateTime CrustPriceCreatedDate { get; set; }
        public DateTime CrustPriceUpdatedDate { get; set; }
        public int CrustPriceStatus { get; set; }
    }
}