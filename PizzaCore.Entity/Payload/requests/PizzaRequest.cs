namespace PizzaCore.Entity.Payload.requests
{
    public class PizzaRequest
    {
        public int Id { get; set; }
        public int SubCate { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Status { get; set; }
        public int Deleted { get; set; }

        public PizzaRequest()
        {
        }

        public PizzaRequest(int id, int subCate, string name, string color, int status, int deleted)
        {
            Id = id;
            SubCate = subCate;
            Name = name;
            Color = color;
            Status = status;
            Deleted = deleted;
        }
    }
}