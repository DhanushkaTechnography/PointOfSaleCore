namespace PizzaCore.Entity.Payload.requests
{
    public class SubCategoryRequest
    {
        public int SubCategoryId { get; set; }
        public int Category { get; set; }
        public string SubCatName { get; set; }
        public int SubCatStatus { get; set; }
    }
}