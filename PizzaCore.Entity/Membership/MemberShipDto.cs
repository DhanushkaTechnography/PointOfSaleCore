using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Membership
{
    public class MemberShipDto
    {
        [Key]
        public int MembershipId { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public double MinimumExpenses { get; set; }
        public int Status { get; set; }
    }
}