using TechShop.Entities.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.dao.Reository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly List<OrderDetail> orderDetails;

        public OrderDetailsRepository()
        {
            orderDetails = new List<OrderDetail>();
        }

        public decimal CalculateTotalAmount(Order order)
        {
            return order.OrderDetails.Sum(od => od.Product.Price * od.Quantity);
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            return orderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailID) ?? new OrderDetail();
        }

        public void UpdateOrderStatus(int orderID)
        {
            // Implementation for updating order status
            Console.WriteLine("Order status updated.");
        }

        public void CancelOrder(int orderID)
        {
            // Implementation for canceling order
            Console.WriteLine("Order canceled.");
        }
    }
}