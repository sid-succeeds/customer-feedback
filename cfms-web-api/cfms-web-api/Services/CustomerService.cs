using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Controller
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        public List<Customer> AddCustomer(Customer customer)
        {
            return _CustomerRepository.AddCustomer(customer);
        }

        public List<Customer> AddCustomers(List<Customer> customers)
        {
            return _CustomerRepository.AddCustomers(customers);
        }

        public List<Customer> DeleteCustomer(string id)
        {
            return _CustomerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _CustomerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(string id)
        {
            return _CustomerRepository.GetCustomerById(id);
        }

        public List<Customer> UpdateCustomer(string id, Customer Customer)
        {
            return _CustomerRepository.UpdateCustomer(id, Customer);
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            return _CustomerRepository.SearchCustomers(searchTerm);
        }

        public List<Customer> GetCustomersPage(int pageNumber, int pageSize)
        {
            int skipCount = (pageNumber - 1) * pageSize;
            return _CustomerRepository.GetCustomersPage(skipCount, pageSize);
        }
    }
}

