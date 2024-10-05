using TechShop.Entities.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.DAO
{
    public class OrderService : IOrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public void PlaceOrder(Order order)
        {
            orders.Add(order);
        }

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderID == orderId);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = GetOrder(order.OrderID);
            if (existingOrder != null)
            {
                existingOrder.Customer = order.Customer;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalAmount = order.TotalAmount;
            }
        }

        public void CancelOrder(int orderId)
        {
            var order = GetOrder(orderId);
            if (order != null)
            {
                orders.Remove(order);
            }
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
}