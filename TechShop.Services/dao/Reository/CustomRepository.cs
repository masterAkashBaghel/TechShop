using TechShop.Entities.Model;


namespace TechShop.Services.dao.Reository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.Email = customer.Email;
                // Update other properties as needed
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public decimal CalculateTotalOrders(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                return customer.Orders.Sum(order => order.TotalAmount);
            }
            return 0;
        }
    }
}