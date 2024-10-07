using System;
using TechShop.Entities.Model;
using TechShop.Services.dao.Services;

namespace TechShop
{
    public static class OrderDetailOperations
    {
        public static void GetOrderDetail(OrderDetailsService orderDetailsService)
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine() ?? string.Empty);
            OrderDetail orderDetail = orderDetailsService.GetOrderDetails(orderDetailId);
            if (orderDetail != null)
            {
                Console.WriteLine($"Order ID: {orderDetail.OrderDetailID}");
                Console.WriteLine($"Quantity: {orderDetail.Quantity}");
            }
            else
            {
                Console.WriteLine("Order detail not found.");
            }
        }

        public static void RemoveOrderDetail(OrderDetailsService orderDetailsService)
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine() ?? string.Empty);
            orderDetailsService.CancelOrder(orderDetailId);
            Console.WriteLine("Order detail removed successfully.");
        }
    }
}