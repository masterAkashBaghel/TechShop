using TechShop.Entities.Model;
using System.Collections.Generic;
using System.Linq;

namespace TechShop.Services.DAO
{
    public class ProductService : IProducts
    {
        private List<Product> products;

        public ProductService()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product GetProductDetails(int productID)
        {
            return products.FirstOrDefault(p => p.ProductID == productID);
        }

        public void UpdateProductInfo(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct == null)
                throw new ArgumentException("Product not found.");

            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Description = product.Description;
        }

        public bool IsProductInStock(int productID)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productID);
            return product != null && product.Inventory.QuantityInStock > 0;
        }
    }
}