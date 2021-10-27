using System.Collections.Generic;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.CustomerMembership;
using PizzaCore.Entity.Membership;

namespace PizzaPos.DataAccess.CustomerRepository
{
    public interface ICustomerRepository
    {
        public bool SaveCustomer(CustomerDto dto);
        public bool UpdateCustomer(CustomerDto dto);
        public CustomerDto SearchByContact(string contact);
        public CustomerDto SearchById(int id);
        public List<CustomerDto> GetAllCustomers();
        public bool AddNewMemberShip(CustomerMembership membership);
        public bool UpdateMemberShip(CustomerMembership membership);
        public CustomerMembership GetMembershipByCustomer(CustomerDto dto);
    }
}