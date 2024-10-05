using System;
using TechShop.Entities.Model;
using TechShop.Services.DAO;

namespace TechShopApp.Operations
{
    public static class ProductOperations
    {
        public static void AddProduct(ProductService productService)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Quantity in Stock: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new Product
            {
                ProductName = name,
                Description = description,
                Price = price,
                Category = category,
                Inventory = new Inventory { QuantityInStock = quantity }
            };

            productService.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        public static void GetProductDetails(ProductService productService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = productService.GetProductDetails(productId);
            if (product != null)
            {
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Category: {product.Category}");
                Console.WriteLine($"Quantity in Stock: {product.Inventory.QuantityInStock}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void UpdateProductInfo(ProductService productService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = productService.GetProductDetails(productId);
            if (product != null)
            {
                Console.Write("Enter New Product Name: ");
                product.ProductName = Console.ReadLine();
                Console.Write("Enter New Description: ");
                product.Description = Console.ReadLine();
                Console.Write("Enter New Price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter New Category: ");
                product.Category = Console.ReadLine();
                Console.Write("Enter New Quantity in Stock: ");
                product.Inventory.QuantityInStock = int.Parse(Console.ReadLine());

                productService.UpdateProductInfo(product);
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void CheckProductStock(ProductService productService)
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            bool inStock = productService.IsProductInStock(productId);
            Console.WriteLine(inStock ? "Product is in stock." : "Product is out of stock.");
        }
    }
}