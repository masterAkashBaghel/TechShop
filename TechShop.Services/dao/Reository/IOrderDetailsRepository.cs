using TechShop.Entities.Model;
using System.Collections.Generic;

namespace TechShop.Services.dao.Reository
{
    public interface IOrderDetailsRepository
    {
        decimal CalculateTotalAmount(Order order);
        OrderDetail GetOrderDetails(int orderDetailID);
        void UpdateOrderStatus(int orderID);
        void CancelOrder(int orderID);
    }
}