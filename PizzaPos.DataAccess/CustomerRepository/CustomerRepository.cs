using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.CustomerMembership;
using PizzaCore.Entity.Membership;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveCustomer(CustomerDto dto)
        {
            _dbContext.CustomerDto.Add(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateCustomer(CustomerDto dto)
        {
            _dbContext.CustomerDto.Update(dto);
            _dbContext.SaveChanges();
            return true;
        }

        public CustomerDto SearchByContact(string contact)
        {
            return _dbContext.CustomerDto.First(dto => dto.CusContact == contact && dto.CusStatus == 1);
        }

        public CustomerDto SearchById(int id)
        {
            return _dbContext.CustomerDto.Find(id);
        }

        public List<CustomerDto> GetAllCustomers()
        {
            return _dbContext.CustomerDto.Where(dto => dto.CusStatus == 1).ToList();
        }

        public bool AddNewMemberShip(CustomerMembership membership)
        {
            _dbContext.CustomerMemberShip.Add(membership);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateMemberShip(CustomerMembership membership)
        {
            _dbContext.CustomerMemberShip.Update(membership);
            _dbContext.SaveChanges();
            return true;
        }

        public CustomerMembership GetMembershipByCustomer(CustomerDto dto)
        {
            return _dbContext.CustomerMemberShip.Include(membership => membership.Customer)
                .Include(membership => membership.Membership)
                .First(membership => membership.Customer == dto && membership.Status == 1);
        }
    }
}