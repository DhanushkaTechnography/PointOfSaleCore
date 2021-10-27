namespace PizzaCore.Entity.Payload
{
    public class PizzaResponse
    {
        public int Id { get; set; }
        public int Cate { get; set; }
        public string Name { get; set; }
        public string CateName { get; set; }
        public string Updated { get; set; }
        public int Ingredients { get; set; }
        public int Sizes { get; set; }
        public int Status { get; set; }

        public PizzaResponse()
        {
        }

        public PizzaResponse(int id, int cate, string name,string cateName, string updated, int ingredients, int sizes, int status)
        {
            Id = id;
            Cate = cate;
            Name = name;
            CateName = cateName;
            Updated = updated;
            Ingredients = ingredients;
            Sizes = sizes;
            Status = status;
        }
    }
}