using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;


namespace TechShop.Services.dao.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerRepository
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public decimal CalculateTotalOrders(int customerId)
        {
            return _customerRepository.CalculateTotalOrders(customerId);
        }
    }
}