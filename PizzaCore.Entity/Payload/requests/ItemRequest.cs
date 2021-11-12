using System.Collections.Generic;

namespace PizzaCore.Entity.Payload.requests
{
    public class ItemRequest
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public string CateName { get; set; }
        public int Status { get; set; }
        public List<PricesRequest> Prices { get; set; }

        public ItemRequest()
        {
        }

        public ItemRequest(int id, int category, string name, string cateName, int status, List<PricesRequest> prices)
        {
            Id = id;
            Category = category;
            Name = name;
            CateName = cateName;
            Status = status;
            Prices = prices;
        }
    }
}