using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechShop.Entities.Model;
using TechShop.Exceptions;

namespace TechShop.Services.dao.Reository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly string _connectionString;

        public OrderDetailsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public decimal CalculateTotalAmount(Order order)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT SUM(od.Quantity * p.Price) FROM OrderDetail od JOIN Product p ON od.ProductID = p.ProductID WHERE od.OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public OrderDetail GetOrderDetails(int orderDetailID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = @"
                    SELECT od.OrderDetailID, od.OrderID, od.ProductID, od.Quantity,
                           o.OrderID, o.CustomerID, o.OrderDate, o.Status,
                           p.ProductID, p.ProductName, p.Description, p.Price, p.InStock, p.Category
                    FROM OrderDetail od
                    JOIN [Order] o ON od.OrderID = o.OrderID
                    JOIN Product p ON od.ProductID = p.ProductID
                    WHERE od.OrderDetailID = @OrderDetailID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var order = new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        Customer = new Customer { CustomerID = (int)reader["CustomerID"] },
                        OrderDate = (DateTime)reader["OrderDate"],
                        Status = reader["Status"].ToString()
                    };

                    var product = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        InStock = (bool)reader["InStock"],
                        Category = reader["Category"].ToString()
                    };

                    return new OrderDetail
                    {
                        OrderDetailID = (int)reader["OrderDetailID"],
                        Order = order,
                        Product = product,
                        Quantity = (int)reader["Quantity"]
                    };
                }
                else
                {
                    throw new OrderDetailNotFoundException(orderDetailID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void UpdateOrderStatus(int orderID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE [Order] SET Status = 'Updated' WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderID);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void CancelOrder(int orderID)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE [Order] SET Status = 'Canceled' WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderID);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }
    }
}