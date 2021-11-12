using System;

namespace PizzaCore.Entity.Payload.requests
{
    public class PaymentDetails
    {
        public int Customer { get; set; }
        public int Order { get; set; }
        public int Method { get; set; }
        public string CardNo { get; set; }
        public string CardExp { get; set; }
        public string CardCvv { get; set; }
    }
}