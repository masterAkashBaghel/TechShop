using System;
using System.Collections.Generic;
using TechShop.Entities.Model;
using TechShop.Services.DAO;

namespace TechShopApp.Operations
{
    public static class OrderOperations
    {
        public static void PlaceOrder(OrderService orderService)
        {
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Order Date (yyyy-mm-dd): ");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Total Amount: ");
            decimal totalAmount = decimal.Parse(Console.ReadLine());

            Order order = new Order
            {
                Customer = new Customer { FirstName = customerName },
                OrderDate = orderDate,
                TotalAmount = totalAmount
            };

            orderService.PlaceOrder(order);
            Console.WriteLine("Order placed successfully.");
        }

        public static void GetOrderDetails(OrderService orderService)
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            Order order = orderService.GetOrder(orderId);
            if (order != null)
            {
                Console.WriteLine($"Customer: {order.Customer.FirstName}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Total Amount: {order.TotalAmount}");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }

        public static void UpdateOrder(OrderService orderService)
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            Order order = orderService.GetOrder(orderId);
            if (order != null)
            {
                Console.Write("Enter New Customer Name: ");
                order.Customer.FirstName = Console.ReadLine();
                Console.Write("Enter New Order Date (yyyy-mm-dd): ");
                order.OrderDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter New Total Amount: ");
                order.TotalAmount = decimal.Parse(Console.ReadLine());

                orderService.UpdateOrder(order);
                Console.WriteLine("Order updated successfully.");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }

        public static void CancelOrder(OrderService orderService)
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            orderService.CancelOrder(orderId);
            Console.WriteLine("Order canceled successfully.");
        }

        public static void ListAllOrders(OrderService orderService)
        {
            List<Order> orders = orderService.GetAllOrders();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.Customer.FirstName}, Order Date: {order.OrderDate}, Total Amount: {order.TotalAmount}");
            }
        }
    }
}