using System;
using TechShop.Entities.Model;
using TechShop.Services.dao.Services;

namespace TechShop
{
    public static class CustomerOperations
    {
        public static void AddCustomer(CustomerService customerService)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            Customer customer = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phoneNumber,
                Address = "123 Main St"
            };

            customerService.AddCustomer(customer);
            Console.WriteLine("Customer added successfully.");
        }

        public static void GetCustomerDetails(CustomerService customerService)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer customer = customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.Phone}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public static void UpdateCustomerInfo(CustomerService customerService)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer customer = customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                Console.Write("Enter New First Name: ");
                customer.FirstName = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter New Last Name: ");
                customer.LastName = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter New Email: ");
                customer.Email = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter New Phone Number: ");
                customer.Phone = Console.ReadLine() ?? string.Empty;

                customerService.UpdateCustomer(customer);
                Console.WriteLine("Customer updated successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
    }
}