using System.ComponentModel.DataAnnotations;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.Membership;


namespace PizzaCore.Entity.CustomerMembership
{
    public class CustomerMembership
    {
        [Key]
        public int RecId { get; set; }
        public CustomerDto Customer { get; set; }
        public MemberShipDto Membership { get; set; }
        public string AssignedDate { get; set; }
        public string UsedUntil { get; set; }
        public int Status { get; set; }

        public CustomerMembership()
        {
        }

        public CustomerMembership(int recId, CustomerDto customer, MemberShipDto membership, string assignedDate, string usedUntil, int status)
        {
            RecId = recId;
            Customer = customer;
            Membership = membership;
            AssignedDate = assignedDate;
            UsedUntil = usedUntil;
            Status = status;
        }
    }
}