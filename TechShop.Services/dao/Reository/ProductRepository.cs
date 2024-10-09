using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechShop.Entities.Model;
using TechShop.Exceptions;

namespace TechShop.Services.dao.Reository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddProduct(Product product)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "INSERT INTO Product (ProductName, Description, Price, Category, InStock) VALUES (@ProductName, @Description, @Price, @Category, @InStock)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@InStock", product.InStock);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public Product GetProductDetails(int productID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT * FROM Product WHERE ProductID = @ProductID";
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
                        Category = reader["Category"].ToString(),
                        InStock = (bool)reader["InStock"]
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

        public void UpdateProductInfo(Product product)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE Product SET ProductName = @ProductName, Description = @Description, Price = @Price, Category = @Category, InStock = @InStock WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@InStock", product.InStock);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public bool IsProductInStock(int productID)
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
                    int quantityInStock = Convert.ToInt32(result);
                    return quantityInStock > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }
    }
}