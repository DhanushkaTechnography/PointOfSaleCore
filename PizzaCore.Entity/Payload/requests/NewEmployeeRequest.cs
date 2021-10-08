namespace PizzaCore.Entity.Payload.requests
{
    public class NewEmployeeRequest
    {
        
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int Role { get; set; }

    }
}