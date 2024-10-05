using TechShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.DAO
{
    public class InventoryService : IInventoryService
    {

        private List<Product> products;
        public InventoryService()
        {
            products = new List<Product>();
        }
        public void AddToInventory(Product product)
        {
            products.Add(product);
        }
        public void RemoveFromInventory(Product product)
        {
            products.Remove(product);
        }
        public void UpdateStockQuantity(Product product, int newQuantity)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct == null)
                throw new ArgumentException("Product not found.");

            existingProduct.QuantityInStock = newQuantity;
        }
        public bool IsProductAvailable(Product product, int quantityToCheck)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct == null)
                throw new ArgumentException("Product not found.");

            return existingProduct.QuantityInStock >= quantityToCheck;
        }
        public double GetInventoryValue()
        {
            return (double)products.Sum(p => p.Price * p.QuantityInStock);
        }
        public List<Product> ListLowStockProducts(int threshold)
        {
            return products.Where(p => p.QuantityInStock < threshold).ToList();
        }
        public List<Product> ListOutOfStockProducts()
        {
            return products.Where(p => p.QuantityInStock == 0).ToList();
        }
        public Product GetProduct(int productID)
        {
            return products.FirstOrDefault(p => p.ProductID == productID);
        }
        public int GetQuantityInStock(int productID)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productID);
            if (product == null)
                throw new ArgumentException("Product not found.");

            return product.QuantityInStock;
        }
    }

}