using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Services.dao.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void PlaceOrder(Order order)
        {
            _orderRepository.PlaceOrder(order);
        }

        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        public void CancelOrder(int orderId)
        {
            _orderRepository.CancelOrder(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
    }
}