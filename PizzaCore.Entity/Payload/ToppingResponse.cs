namespace PizzaCore.Entity.Payload
{
    public class ToppingResponse
    {
        public int ToppingsId { get; set; }
        public int CategoryId { get; set; }
        public int Status { get; set; }
        public string ToppingName { get; set; }
        
        public string CategoryName { get; set; }

        public ToppingResponse()
        {
        }

        public ToppingResponse(int toppingsId, int categoryId, int status, string toppingName,string categoryName)
        {
            ToppingsId = toppingsId;
            CategoryId = categoryId;
            Status = status;
            ToppingName = toppingName;
            CategoryName = categoryName;
        }
    }
}