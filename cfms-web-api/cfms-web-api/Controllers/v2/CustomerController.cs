using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller.v2
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        #region GET Methods
        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>The HTTP status code and a list of all customers.</returns>
        /// <response code="200">Returns a list of all customers.</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _CustomerService.GetAllCustomers();
        }

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The HTTP status code and the customer with the specified ID.</returns>
        /// <response code="200">Returns the customer with the specified ID.</response>
        /// <response code="404">If the customer is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
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
        /// Searches for customers based on a search term.
        /// </summary>
        /// <param name="searchTerm">The search term to match against customer names or emails.</param>
        /// <returns>The HTTP status code and a list of customers matching the search term.</returns>
        /// <response code="200">Returns a list of customers matching the search term.</response>
        [HttpGet("Search")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public ActionResult<List<Customer>> SearchCustomers(string searchTerm)
        {
            return _CustomerService.SearchCustomers(searchTerm);
        }

        /// <summary>
        /// Retrieves a specific page of customers based on pagination parameters.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The HTTP status code and a page of customers.</returns>
        /// <response code="200">Returns a page of customers.</response>
        [HttpGet("Page")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public ActionResult<List<Customer>> GetCustomersPage(int pageNumber, int pageSize)
        {
            return _CustomerService.GetCustomersPage(pageNumber, pageSize);
        }

        #endregion

        #region POST Methods

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="Customer">The customer to add.</param>
        /// <returns>The HTTP status code and the added customer.</returns>
        /// <response code="201">Returns the added customer.</response>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<Customer>))]
        public ActionResult<List<Customer>> AddCustomer(Customer Customer)
        {
            return _CustomerService.AddCustomer(Customer);         
        }

        /// <summary>
        /// Adds multiple customers in bulk.
        /// </summary>
        /// <param name="customers">The list of customers to add.</param>
        /// <returns>The HTTP status code and the added customers.</returns>
        /// <response code="201">Returns the added customers.</response>
        [HttpPost("Bulk")]
        [ProducesResponseType(201, Type = typeof(List<Customer>))]
        public ActionResult<List<Customer>> AddCustomers(List<Customer> customers)
        {
            return _CustomerService.AddCustomers(customers);
        }

        #endregion

        #region PUT Methods
        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="id">The ID of the customer to update.</param>
        /// <param name="Customer">The updated customer data.</param>
        /// <returns>The HTTP status code and the updated customer.</returns>
        /// <response code="200">Returns the updated customer.</response>
        /// <response code="404">If the customer is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        [ProducesResponseType(404)]
        public ActionResult<List<Customer>> UpdateCustomer(string id, Customer Customer)
        {
            var updatedCustomers = _CustomerService.UpdateCustomer(id, Customer);
            if (updatedCustomers == null)
            {
                return NotFound();
            }
            return updatedCustomers;
        }
        #endregion

        #region DELETE Methods
        /// <summary>
        /// Deletes a customer.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">If the deletion was successful.</response>
        /// <response code="404">If the customer is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<Customer>> DeleteCustomer(string id)
        {
            var deletedCustomers = _CustomerService.DeleteCustomer(id);
            if (deletedCustomers == null)
            {
                return NotFound();
            }
            return deletedCustomers;
        }

        /// <summary>
        /// Deletes all customer records.
        /// </summary>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">If all customer deletions were successful.</response>
        /// <response code="404">If nothing was found.</response>
        [HttpDelete("All")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public void DeleteAllCustomers()
        {
            _CustomerService.DeleteAllCustomers();
        }
        #endregion
    }
}