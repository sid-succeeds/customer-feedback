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

        public List<Customer> DeleteCustomer(int id)
        {
            return _CustomerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _CustomerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _CustomerRepository.GetCustomerById(id);
        }

        public List<Customer> UpdateCustomer(int id, Customer Customer)
        {
            return _CustomerRepository.UpdateCustomer(id, Customer);
        }
    }
}

