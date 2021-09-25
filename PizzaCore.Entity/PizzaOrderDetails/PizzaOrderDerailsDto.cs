using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.Pizza;

namespace PizzaCore.Entity.PizzaOrderDetails
{
    public class PizzaOrderDerailsDto
    {
        [Key]
        public int PizzaOrderDetailsId { get; set; }
        public OrderDto PizzaOrderId { get; set; }
        public PizzaDto PizzaId { get; set; }
        public float PizzaOrderDetailsPrice { get; set; }
        public DateTime CreateDet { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        
    }
}