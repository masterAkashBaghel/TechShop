
using TechShop.Entities.Model;
using System.Collections.Generic;


namespace TechShop.Services.DAO
{
    public interface ICustomerService
    {

        void AddCustomer(Customer customer);
        int CalculateTotalOrders(Customer customer);
        Customer GetCustomerDetails(int customerID);
        void UpdateCustomerInfo(Customer customer);
    }
}
