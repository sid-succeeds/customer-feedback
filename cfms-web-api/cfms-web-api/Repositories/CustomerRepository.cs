using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Controller
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customerList = new List<Customer>()
        {
            new Customer(1, "John", "Doe", "john.doe@example.com"),
            new Customer(2, "Jane", "Smith", "jane.smith@example.com"),
            new Customer(3, "Michael", "Chen", "michael.chen@example.com"),
            new Customer(4, "Alice", "Garcia", "alice.garcia@example.com"),
            new Customer(5, "David", "Lee", "david.lee@example.com"),
        };

        public List<Customer> GetAllCustomers()
        {
            return customerList.ToList(); // Return a copy to avoid modifying the internal list
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return customerList.FirstOrDefault(c => c.Id == id);
            }
            catch
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public List<Customer> AddCustomer(Customer customer)
        {
            // Implement logic to assign a unique ID (e.g., database auto-increment)
            customer.Id = customerList.Count + 1; // Temporary for in-memory list
            customerList.Add(customer);
            return customerList.ToList();
        }

        public List<Customer> UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = customerList.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                // Update other properties if needed
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
            return customerList.ToList();
        }

        public List<Customer> DeleteCustomer(int id)
        {
            var customerToDelete = customerList.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {
                customerList.Remove(customerToDelete);
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
            return customerList.ToList();
        }
    }
}
