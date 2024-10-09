using System;
using TechShop.Entities.Model;
using TechShop.Services.dao.Services;


namespace TechShop
{
    public static class ProductOperations
    {
        public static void AddProduct(ProductService productService)
        {
            try
            {
                Console.WriteLine("Enter Product Details:");
                Console.Write("Enter product id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid product id.");
                    return;
                }

                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Description: ");
                string description = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid price.");
                    return;
                }

                Console.Write("Enter Category: ");
                string category = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Quantity in Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                Console.Write("In Stock (true/false or 1/0): ");
                string inStockInput = Console.ReadLine() ?? string.Empty;
                bool inStock;
                if (inStockInput == "1")
                {
                    inStock = true;
                }
                else if (inStockInput == "0")
                {
                    inStock = false;
                }
                else if (!bool.TryParse(inStockInput, out inStock))
                {
                    Console.WriteLine("Invalid input. Please enter 'true', 'false', '1', or '0'.");
                    return;
                }

                Product product = new()
                {
                    ProductID = id,
                    ProductName = name,
                    Description = description,
                    Price = price,
                    Category = category,
                    InStock = inStock,
                    Inventory = new Inventory { QuantityInStock = quantity }
                };

                productService.AddProduct(product);
                Console.WriteLine("Product added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. Please try again later." + ex.Message);

            }
        }

        public static void GetProductDetails(ProductService productService)
        {
            try
            {
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product id.");
                    return;
                }

                Product product = productService.GetProductDetails(productId);
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Category: {product.Category}");
                Console.WriteLine($"In Stock: {product.InStock}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void UpdateProductInfo(ProductService productService)
        {
            try
            {
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product id.");
                    return;
                }

                Product product = productService.GetProductDetails(productId);
                if (product != null)
                {
                    Console.Write("Enter New Product Name: ");
                    product.ProductName = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter New Description: ");
                    product.Description = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter New Price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.WriteLine("Invalid price.");
                        return;
                    }
                    product.Price = price;

                    Console.Write("Enter New Category: ");
                    product.Category = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter New Quantity in Stock: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        return;
                    }
                    product.Inventory.QuantityInStock = quantity;
                    product.InStock = quantity > 0;

                    productService.UpdateProductInfo(product);
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void CheckProductStock(ProductService productService)
        {
            try
            {
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product id.");
                    return;
                }

                bool inStock = productService.IsProductInStock(productId);
                Console.WriteLine(inStock ? "Product is in stock." : "Product is out of stock.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. Please try again later." + ex.Message);

            }
        }
    }
}