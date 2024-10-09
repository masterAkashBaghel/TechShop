using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechShop.Entities.Model;
using TechShop.Exceptions;

namespace TechShop.Services.dao.Reository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void PlaceOrder(Order order)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "INSERT INTO [Order] (CustomerID, OrderDate, TotalAmount, Status) VALUES (@CustomerID, @OrderDate, @TotalAmount, @Status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                command.Parameters.AddWithValue("@Status", order.Status);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public Order GetOrder(int orderId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT * FROM [Order] WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        CustomerID = (int)reader["CustomerID"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        TotalAmount = (decimal)reader["TotalAmount"],
                        Status = reader["Status"].ToString()
                    };
                }
                else
                {
                    throw new OrderNotFoundException(orderId);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE [Order] SET CustomerID = @CustomerID, OrderDate = @OrderDate, TotalAmount = @TotalAmount, Status = @Status WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                command.Parameters.AddWithValue("@Status", order.Status);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void CancelOrder(int orderId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "UPDATE [Order] SET Status = 'Canceled' WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                using SqlConnection connection = new SqlConnection(_connectionString);
                string query = "SELECT * FROM [Order]";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        CustomerID = (int)reader["CustomerID"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        TotalAmount = (decimal)reader["TotalAmount"],
                        Status = reader["Status"].ToString()
                    });
                }
                return orders;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }
    }
}