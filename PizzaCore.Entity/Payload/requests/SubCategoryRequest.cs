namespace PizzaCore.Entity.Payload.requests
{
    public class SubCategoryRequest
    {
        public int SubCategoryId { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public string SubCatName { get; set; }
        public int SubCatStatus { get; set; }
        public int Deleted { get; set; }
    }
}