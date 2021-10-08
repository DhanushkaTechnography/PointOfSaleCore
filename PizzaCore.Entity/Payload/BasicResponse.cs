namespace PizzaCore.Entity.Payload
{
    public class BasicResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BasicResponse()
        {
        }

        public BasicResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    
}