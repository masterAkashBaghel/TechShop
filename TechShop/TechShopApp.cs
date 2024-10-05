﻿using System;
using TechShop.Services.DAO;
using TechShopApp.Operations;

namespace TechShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            OrderService orderService = new OrderService();
            InventoryService inventoryService = new InventoryService();
            CustomerService customerService = new CustomerService();
            OrderDetailsService orderDetailsService = new OrderDetailsService();

            while (true)
            {
                Console.WriteLine("TechShop Console App");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Get Product Details");
                Console.WriteLine("3. Update Product Info");
                Console.WriteLine("4. Check Product Stock");
                Console.WriteLine("5. Place Order");
                Console.WriteLine("6. Get Order Details");
                Console.WriteLine("7. Update Order");
                Console.WriteLine("8. Cancel Order");
                Console.WriteLine("9. List All Orders");
                Console.WriteLine("10. Add to Inventory");
                Console.WriteLine("11. Remove from Inventory");
                Console.WriteLine("12. Update Inventory Quantity");
                Console.WriteLine("13. Check Product Availability in Inventory");
                Console.WriteLine("14. Add Customer");
                Console.WriteLine("15. Get Customer Details");
                Console.WriteLine("16. Update Customer Info");
                Console.WriteLine("17. Get Order Detail");
                Console.WriteLine("18. Remove Order Detail");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ProductOperations.AddProduct(productService);
                        break;
                    case "2":
                        ProductOperations.GetProductDetails(productService);
                        break;
                    case "3":
                        ProductOperations.UpdateProductInfo(productService);
                        break;
                    case "4":
                        ProductOperations.CheckProductStock(productService);
                        break;
                    case "5":
                        OrderOperations.PlaceOrder(orderService);
                        break;
                    case "6":
                        OrderOperations.GetOrderDetails(orderService);
                        break;
                    case "7":
                        OrderOperations.UpdateOrder(orderService);
                        break;
                    case "8":
                        OrderOperations.CancelOrder(orderService);
                        break;
                    case "9":
                        OrderOperations.ListAllOrders(orderService);
                        break;
                    case "10":
                        InventoryOperations.AddToInventory(inventoryService);
                        break;
                    case "11":
                        InventoryOperations.RemoveFromInventory(inventoryService);
                        break;
                    case "12":
                        InventoryOperations.UpdateInventoryQuantity(inventoryService);
                        break;
                    case "13":
                        InventoryOperations.CheckProductAvailability(inventoryService);
                        break;
                    case "14":
                        CustomerOperations.AddCustomer(customerService);
                        break;
                    case "15":
                        CustomerOperations.GetCustomerDetails(customerService);
                        break;
                    case "16":
                        CustomerOperations.UpdateCustomerInfo(customerService);
                        break;
                    case "17":
                        OrderDetailOperations.GetOrderDetail(orderDetailsService);
                        break;
                    case "18":
                        OrderDetailOperations.RemoveOrderDetail(orderDetailsService);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}