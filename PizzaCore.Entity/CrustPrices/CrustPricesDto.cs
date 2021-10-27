using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.CrustPrices
{
    public class CrustPricesDto
    {
        [Key]
        public int CrustPriceId { get; set; }
        public CrustDto Crust { get; set; }
        public SizesDto CrustSize { get; set; }
        public double CrustPrice { get; set; }
        public string CrustPriceCreatedDate { get; set; }
        public string CrustPriceUpdatedDate { get; set; }
        public int CrustPriceStatus { get; set; }

        public CrustPricesDto()
        {
        }

        public CrustPricesDto(CrustDto crust, SizesDto crustSize, double crustPrice, string crustPriceCreatedDate, string crustPriceUpdatedDate, int crustPriceStatus)
        {
            Crust = crust;
            CrustSize = crustSize;
            CrustPrice = crustPrice;
            CrustPriceCreatedDate = crustPriceCreatedDate;
            CrustPriceUpdatedDate = crustPriceUpdatedDate;
            CrustPriceStatus = crustPriceStatus;
        }
    }
}