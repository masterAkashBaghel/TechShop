using TechShop.Entities.Model;

namespace TechShop.Services.DAO
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        Order GetOrder(int orderId);
        void UpdateOrder(Order order);
        void CancelOrder(int orderId);
        List<Order> GetAllOrders();
    }
}