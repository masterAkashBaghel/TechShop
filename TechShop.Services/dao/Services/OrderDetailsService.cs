using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Services.dao.Services
{
    public class OrderDetailsService(IOrderDetailsRepository orderDetailsRepository) : IOrderDetailsRepository
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository = orderDetailsRepository;

        public decimal CalculateTotalAmount(Order order)
        {
            return _orderDetailsRepository.CalculateTotalAmount(order);
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            return _orderDetailsRepository.GetOrderDetails(orderDetailID);
        }

        public void UpdateOrderStatus(int orderID)
        {
            _orderDetailsRepository.UpdateOrderStatus(orderID);
        }

        public void CancelOrder(int orderID)
        {
            _orderDetailsRepository.CancelOrder(orderID);
        }
    }
}