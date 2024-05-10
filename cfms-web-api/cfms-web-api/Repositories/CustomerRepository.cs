using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(string id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id.Equals(id)) ?? throw new ArgumentException("Customer not found.");
        }

        public List<Customer> AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                throw new Exception("Error occurred while adding customer.", ex);
            }
        }

        public List<Customer> AddCustomers(List<Customer> customers)
        {
            try
            {
                _context.Customers.AddRange(customers);
                _context.SaveChanges();
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                throw new Exception("Error occurred while adding customers.", ex);
            }
        }

        public List<Customer> UpdateCustomer(string id, Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id.Equals(id));
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                // Update other properties if needed
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
            return _context.Customers.ToList();
        }

        public List<Customer> DeleteCustomer(string id)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(c => c.Id.Equals(id));
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
            return _context.Customers.ToList();
        }

        public void DeleteAllCustomers()
        {
            _context.Customers.RemoveRange(_context.Customers);
            _context.SaveChanges();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            return _context.Customers
                .Where(c => c.FirstName.Contains(searchTerm) || c.LastName.Contains(searchTerm) || c.Email.Contains(searchTerm))
                .ToList();
        }

        public List<Customer> GetCustomersPage(int skipCount, int pageSize)
        {
            return _context.Customers
                .Skip(skipCount)
                .Take(pageSize)
                .ToList();
        }
    }
}
