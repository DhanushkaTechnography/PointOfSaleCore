using System.Collections.Generic;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.CustomerMembership;
using PizzaCore.Entity.Membership;

namespace PizzaCore.Business.CustomerService
{
    public interface ICustomerService
    {
        // MEMBERSHIP
        public bool SaveMemberShip(MemberShipDto dto);
        public MemberShipDto GetMemberShipById(int id);
        public List<MemberShipDto> AllMemberShips();
        public bool AssignMembership(string customer,int membership);
        public CustomerMembership GetCustomerActiveMembership(string customer);
        
        // CUSTOMER
        public int SaveCustomer(CustomerDto dto);
        public CustomerDto SearchByContact(string contact);
        public List<CustomerDto> AllCustomers();
    }
}