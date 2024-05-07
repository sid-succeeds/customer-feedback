using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface ICustomerRepository
	{
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        List<Customer> AddCustomer(Customer customer);
        List<Customer> UpdateCustomer(int id, Customer customer);
        List<Customer> DeleteCustomer(int id);
    }
}

