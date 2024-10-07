using TechShop.Entities.Model;
namespace TechShop.Services.dao.Reository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        decimal CalculateTotalOrders(int customerId);
    }
}