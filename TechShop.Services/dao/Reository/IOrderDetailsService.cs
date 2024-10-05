using TechShop.Entities.Model;
using System.Collections.Generic;

namespace TechShop.Services.DAO
{
    public interface IOrderDetailsService
    {
        decimal CalculateTotalAmount(Order order);
        OrderDetail GetOrderDetails(int orderDetailID);
        void UpdateOrderStatus(int orderID);
        void CancelOrder(int orderID);
    }
}