﻿using System;
using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface ICustomerService
	{
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(string id);
        List<Customer> AddCustomer(Customer customer);
        List<Customer> AddCustomers(List<Customer> customers);
        List<Customer> UpdateCustomer(string id, Customer customer);
        List<Customer> DeleteCustomer(string id);

        List<Customer> SearchCustomers(string searchTerm);
        List<Customer> GetCustomersPage(int pageNumber, int pageSize);
    }
}

