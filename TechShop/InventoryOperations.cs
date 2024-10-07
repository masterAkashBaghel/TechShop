using System;
using TechShop.Entities.Model;
using TechShop.Services.dao.Services;

namespace TechShop
{
    public static class InventoryOperations
    {
        public static void AddToInventory(InventoryService inventoryService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Enter Quantity to Add: ");
            int quantity = int.Parse(Console.ReadLine() ?? string.Empty);

            Product product = inventoryService.GetProduct(productId);
            if (product != null)
            {
                inventoryService.AddToInventory(product);
                Console.WriteLine("Inventory updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void RemoveFromInventory(InventoryService inventoryService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? string.Empty);

            Product product = inventoryService.GetProduct(productId);
            if (product != null)
            {
                inventoryService.RemoveFromInventory(product);
                Console.WriteLine("Inventory updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void UpdateInventoryQuantity(InventoryService inventoryService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Enter New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine() ?? string.Empty);

            Product product = inventoryService.GetProduct(productId);
            if (product != null)
            {
                inventoryService.UpdateStockQuantity(product, newQuantity);
                Console.WriteLine("Inventory updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void CheckProductAvailability(InventoryService inventoryService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Enter Quantity to Check: ");
            int quantityToCheck = int.Parse(Console.ReadLine() ?? string.Empty);

            Product product = inventoryService.GetProduct(productId);
            if (product != null)
            {
                bool available = inventoryService.IsProductAvailable(product, quantityToCheck);
                Console.WriteLine(available ? "Product is available." : "Product is not available.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}