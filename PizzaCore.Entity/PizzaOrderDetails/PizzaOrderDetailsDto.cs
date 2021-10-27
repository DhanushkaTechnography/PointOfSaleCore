using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Crust;
using PizzaCore.Entity.CrustPrices;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.Pizza;
using PizzaCore.Entity.PizzaSizes;
using PizzaCore.Entity.Sizes;

namespace PizzaCore.Entity.PizzaOrderDetails
{
    public class PizzaOrderDetailsDto
    {
        [Key]
        public int PizzaOrderDetailsId { get; set; }
        public OrderDto Order { get; set; }
        public PizzaSizesDto Pizza { get; set; }
        public CrustPricesDto Crust { get; set; }
        public float PizzaSubTotal { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }

        public PizzaOrderDetailsDto()
        {
        }

        public PizzaOrderDetailsDto(int pizzaOrderDetailsId, OrderDto order, PizzaSizesDto pizza, CrustPricesDto crust, float pizzaSubTotal, string note, int status)
        {
            PizzaOrderDetailsId = pizzaOrderDetailsId;
            Order = order;
            Pizza = pizza;
            Crust = crust;
            PizzaSubTotal = pizzaSubTotal;
            Note = note;
            Status = status;
        }
    }
}