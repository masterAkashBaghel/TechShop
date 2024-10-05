using TechShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.DAO
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers;

        public CustomerService()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public int CalculateTotalOrders(Customer customer)
        {
            return customer.Orders.Count;
        }

        public Customer GetCustomerDetails(int customerID)
        {
            return customers.FirstOrDefault(c => c.CustomerID == customerID);
        }

        public void UpdateCustomerInfo(Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer == null)
                throw new ArgumentException("Customer not found.");

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;
        }
    }
}