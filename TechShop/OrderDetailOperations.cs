using System;
using TechShop.Entities.Model;
using TechShop.Services.DAO;

namespace TechShopApp.Operations
{
    public static class OrderDetailOperations
    {
        public static void GetOrderDetail(OrderDetailsService orderDetailsService)
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine());
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
            int orderDetailId = int.Parse(Console.ReadLine());
            orderDetailsService.CancelOrder(orderDetailId);
            Console.WriteLine("Order detail removed successfully.");
        }
    }
}