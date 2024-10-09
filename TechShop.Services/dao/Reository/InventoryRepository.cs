using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechShop.Entities.Model;
using TechShop.Exceptions;

namespace TechShop.Services.dao.Reository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddToInventory(Product product)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "INSERT INTO Product (ProductName, Description, Price, InStock, Category) VALUES (@ProductName, @Description, @Price, @InStock, @Category)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@InStock", product.InStock);
                command.Parameters.AddWithValue("@Category", product.Category);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Product added to inventory.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void RemoveFromInventory(Product product)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "DELETE FROM Product WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Product removed from inventory.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void UpdateStockQuantity(Product product, int newQuantity)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE Inventory SET QuantityInStock = @QuantityInStock, LastStockUpdate = @LastStockUpdate WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@QuantityInStock", newQuantity);
                command.Parameters.AddWithValue("@LastStockUpdate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Stock quantity updated.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public bool IsProductAvailable(Product product, int quantityToCheck)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT QuantityInStock FROM Inventory WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int quantityInStock = Convert.ToInt32(result);
                    return quantityInStock >= quantityToCheck;
                }
                else
                {
                    throw new ProductNotFoundException(product.ProductID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public double GetInventoryValue()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT SUM(p.Price * i.QuantityInStock) FROM Product p JOIN Inventory i ON p.ProductID = i.ProductID";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDouble(result);
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public List<Product> ListLowStockProducts(int threshold)
        {
            try
            {
                List<Product> products = new List<Product>();
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT p.ProductID, p.ProductName, p.Description, p.Price, p.InStock, p.Category, i.QuantityInStock FROM Product p JOIN Inventory i ON p.ProductID = i.ProductID WHERE i.QuantityInStock < @Threshold";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Threshold", threshold);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        InStock = (bool)reader["InStock"],
                        Category = reader["Category"].ToString(),
                        QuantityInStock = (int)reader["QuantityInStock"]
                    });
                }
                return products;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public List<Product> ListOutOfStockProducts()
        {
            try
            {
                List<Product> products = new List<Product>();
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT p.ProductID, p.ProductName, p.Description, p.Price, p.InStock, p.Category, i.QuantityInStock FROM Product p JOIN Inventory i ON p.ProductID = i.ProductID WHERE i.QuantityInStock = 0";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        InStock = (bool)reader["InStock"],
                        Category = reader["Category"].ToString(),
                        QuantityInStock = (int)reader["QuantityInStock"]
                    });
                }
                return products;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public Product GetProduct(int productID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT p.ProductID, p.ProductName, p.Description, p.Price, p.InStock, p.Category, i.QuantityInStock FROM Product p JOIN Inventory i ON p.ProductID = i.ProductID WHERE p.ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productID);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        InStock = (bool)reader["InStock"],
                        Category = reader["Category"].ToString(),
                        QuantityInStock = (int)reader["QuantityInStock"]
                    };
                }
                else
                {
                    throw new ProductNotFoundException(productID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public int GetQuantityInStock(int productID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT QuantityInStock FROM Inventory WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productID);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new ProductNotFoundException(productID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }
    }
}