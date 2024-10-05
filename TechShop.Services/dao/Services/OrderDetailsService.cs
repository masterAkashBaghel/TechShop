using TechShop.Entities.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.DAO
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private List<OrderDetail> orderDetails;

        public OrderDetailsService()
        {
            orderDetails = new List<OrderDetail>();
        }

        public decimal CalculateTotalAmount(Order order)
        {
            return order.OrderDetails.Sum(od => od.Product.Price * od.Quantity);
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            return orderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailID);
        }

        public void UpdateOrderStatus(int orderID)
        {
            Console.WriteLine("Order status updated.");
        }

        public void CancelOrder(int orderID)
        {
            Console.WriteLine("Order canceled.");
        }
    }
}