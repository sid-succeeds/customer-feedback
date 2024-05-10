using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller.v1
{
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    [Obsolete]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _CustomerService.GetAllCustomers();
        }

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
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

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="Customer">The customer to add.</param>
        [HttpPost]
        public ActionResult<List<Customer>> AddCustomer(Customer Customer)
        {
            return _CustomerService.AddCustomer(Customer);
        }

        /// <summary>
        /// Adds multiple customers in bulk.
        /// </summary>
        /// <param name="customers">The list of customers to add.</param>
        [HttpPost("Bulk")]
        public ActionResult<List<Customer>> AddCustomers(List<Customer> customers)
        {
            return _CustomerService.AddCustomers(customers);
        }

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="id">The ID of the customer to update.</param>
        /// <param name="Customer">The updated customer data.</param>
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

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
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