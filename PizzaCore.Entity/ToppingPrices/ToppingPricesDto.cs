using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Category;
using PizzaCore.Entity.Sizes;
using PizzaCore.Entity.Toppings;

namespace PizzaCore.Entity.ToppingPrices
{
    public class ToppingPricesDto
    {
        [Key]
        public int ToppingPriceId { get; set; }
        public ToppingsDto Topping { get; set; }
        public SizesDto ToppingSize { get; set; }
        public double ToppingPrice { get; set; }
        public string ToppingPriceCreatedDate { get; set; }
        public string ToppingPriceUpdatedDate { get; set; }
        public int ToppingPriceStatus { get; set; }

        public ToppingPricesDto()
        {
        }

        public ToppingPricesDto(int toppingPriceId, ToppingsDto topping, SizesDto toppingSize, double toppingPrice, string toppingPriceCreatedDate, string toppingPriceUpdatedDate, int toppingPriceStatus)
        {
            ToppingPriceId = toppingPriceId;
            Topping = topping;
            ToppingSize = toppingSize;
            ToppingPrice = toppingPrice;
            ToppingPriceCreatedDate = toppingPriceCreatedDate;
            ToppingPriceUpdatedDate = toppingPriceUpdatedDate;
            ToppingPriceStatus = toppingPriceStatus;
        }
    }
}