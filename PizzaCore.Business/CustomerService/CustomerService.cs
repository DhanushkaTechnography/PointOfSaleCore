using System;
using System.Collections.Generic;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.CustomerMembership;
using PizzaCore.Entity.Membership;
using PizzaPos.DataAccess.CustomerRepository;
using PizzaPos.DataAccess.MemberShipRepository;

namespace PizzaCore.Business.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMemberShipRepository _memberShipRepository;

        public CustomerService(ICustomerRepository customerRepository, IMemberShipRepository memberShipRepository)
        {
            _customerRepository = customerRepository;
            _memberShipRepository = memberShipRepository;
        }

        public bool SaveMemberShip(MemberShipDto dto)
        {
            var byId = _memberShipRepository.FindMembershipById(dto.MembershipId);
            if (byId == null)
            {
                return _memberShipRepository.CreateNewMembership(dto);
            }
            byId.Name = dto.Name;
            byId.Status = dto.Status;
            byId.MinimumExpenses = dto.MinimumExpenses;
            byId.OrderCount = dto.OrderCount;
            return _memberShipRepository.UpdateMembership(byId);
        }

        public MemberShipDto GetMemberShipById(int id)
        {
            return _memberShipRepository.FindMembershipById(id);
        }

        public List<MemberShipDto> AllMemberShips()
        {
            return _memberShipRepository.FindAllMemberShips();
        }

        public bool AssignMembership(string customer, int membership)
        {
            var customerDto = _customerRepository.SearchByContact(customer);
            var memberShipDto = _memberShipRepository.FindMembershipById(membership);
            var m = _customerRepository.GetMembershipByCustomer(customerDto);
            if (m != null)
            {
                m.Status = 0;
                m.UsedUntil = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                _customerRepository.UpdateMemberShip(m);
            }
            m = new CustomerMembership(0, customerDto, memberShipDto, $"{DateTime.Now:d/M/yyyy HH:mm:ss}", "--", 1);
            return _customerRepository.AddNewMemberShip(m);
        }

        public CustomerMembership GetCustomerActiveMembership(string customer)
        {
            return _customerRepository.GetMembershipByCustomer(_customerRepository.SearchByContact(customer));
        }

        public bool SaveCustomer(CustomerDto dto)
        {
            CustomerDto byContact;
            try
            {
                byContact = _customerRepository.SearchByContact(dto.CusContact);
            }
            catch (InvalidOperationException e)
            {
                dto.CusCreatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                dto.CusUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                return _customerRepository.SaveCustomer(dto: dto);
            }
            byContact.CusAddress = dto.CusAddress;
            byContact.CusCity = dto.CusCity;
            byContact.CusCountry = dto.CusCountry;
            byContact.CusName = dto.CusName;
            byContact.CusStatus = dto.CusStatus;
            byContact.CusUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
            return _customerRepository.UpdateCustomer(byContact);
        }

        public CustomerDto SearchByContact(string contact)
        {
            return _customerRepository.SearchByContact(contact);
        }

        public List<CustomerDto> AllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}