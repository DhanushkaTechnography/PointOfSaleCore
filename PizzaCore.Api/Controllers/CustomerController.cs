using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.CustomerService;
using PizzaCore.Entity.Customer;
using PizzaCore.Entity.Membership;

namespace PizzaCore.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // MEMBERSHIP
        [HttpPost]
        [Route("new_membership")]
        public async Task<IActionResult> NewMembership([FromBody] MemberShipDto model)
        {
            return Ok(_customerService.SaveMemberShip(model));
        }
        [HttpGet]
        [Route("membership_by_id")]
        public async Task<IActionResult> SearchMembership(int id)
        {
            return Ok(new
            {
                data = _customerService.GetMemberShipById(id)
            });
        }
        [HttpGet]
        [Route("all_memberships")]
        public async Task<IActionResult> AllMemberships()
        {
            return Ok(new
            {
                data = _customerService.AllMemberShips()
            });
        }
        
        // CUSTOMER
        [HttpPost]
        [Route("save_customer")]
        public async Task<IActionResult> SaveCustomer([FromBody] CustomerDto model)
        {
            return Ok(_customerService.SaveCustomer(model));
        }
        
        [HttpGet]
        [Route("customer_by_contact")]
        public async Task<IActionResult> SearchCustomerByContact(string contact)
        {
            return Ok(new
            {
                data = _customerService.SearchByContact(contact)
            });
        }
        
        [HttpGet]
        [Route("all_customers")]
        public async Task<IActionResult> AllCustomers()
        {
            return Ok(new
            {
                data = _customerService.AllCustomers()
            });
        }
    }
}