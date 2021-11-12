using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.orderResponses
{
    public class PizzaItemResponse
    {
        public int PizzaDetailsId { get; set; }
        public int Order { get; set; }
        public int PizzaSizeId { get; set; }
        public int CrustPriceId { get; set; }
        public string PizzaSizeName { get; set; }
        public string PizzaName { get; set; }
        public string PizzaCrustName { get; set; }
        public double SubTotal { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public int Status { get; set; }
        public int Qty { get; set; }
        public List<ExtraToppingResponse> ToppingResponses { get; set; }

        public PizzaItemResponse()
        {
        }

        public PizzaItemResponse(int pizzaDetailsId, int order, int pizzaSizeId, int crustPriceId, string pizzaSizeName,string pizzaName, string pizzaCrustName, double subTotal, string note, string color,int status, List<ExtraToppingResponse> toppingResponses,int qty)
        {
            PizzaDetailsId = pizzaDetailsId;
            Order = order;
            PizzaSizeId = pizzaSizeId;
            CrustPriceId = crustPriceId;
            PizzaSizeName = pizzaSizeName;
            PizzaName = pizzaName;
            PizzaCrustName = pizzaCrustName;
            SubTotal = subTotal;
            Note = note;
            Status = status;
            Color = color;
            ToppingResponses = toppingResponses;
            Qty = qty;
        }
    }
}