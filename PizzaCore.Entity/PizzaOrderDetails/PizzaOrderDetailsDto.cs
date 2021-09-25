using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaCore.Entity.Order;
using PizzaCore.Entity.Pizza;

namespace PizzaCore.Entity.PizzaOrderDetails
{
    public class PizzaOrderDetailsDto
    {
        [Key]
        public int PizzaOrderDetailsId { get; set; }
        
        public OrderDto PizzaOrder { get; set; }
        public PizzaDto Pizza { get; set; }
        
        public float PizzaOrderDetailsPrice { get; set; }
        public DateTime PizzaOrderDetailsCreateDet { get; set; }
        public DateTime PizzaOrderDetailsUpdateDate { get; set; }
        public int PizzaOrderDetailsStatus { get; set; }
        
    }
}