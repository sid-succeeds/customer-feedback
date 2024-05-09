using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet("bulk")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _CustomerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(string id)
        {
            var Customer = _CustomerService.GetCustomerById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Customer;
        }

        [HttpPost]
        public ActionResult<List<Customer>> AddCustomer(Customer Customer)
        {
            return _CustomerService.AddCustomer(Customer);
        }

        [HttpPost("bulk")]
        public ActionResult<List<Customer>> AddCustomers(List<Customer> customers)
        {
            return _CustomerService.AddCustomers(customers);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Customer>> UpdateCustomer(string id, Customer Customer)
        {
            var updatedCustomers = _CustomerService.UpdateCustomer(id, Customer);
            if (updatedCustomers == null)
            {
                return NotFound();
            }
            return updatedCustomers;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Customer>> DeleteCustomer(string id)
        {
            var deletedCustomers = _CustomerService.DeleteCustomer(id);
            if (deletedCustomers == null)
            {
                return NotFound();
            }
            return deletedCustomers;
        }
    }
}