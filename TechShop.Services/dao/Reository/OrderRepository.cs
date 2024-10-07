using TechShop.Entities.Model;

namespace TechShop.Services.dao.Reository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();
        }

        public void PlaceOrder(Order order)
        {
            orders.Add(order);
        }

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderID == orderId)!;
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