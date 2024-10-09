using System;
using System.Data.SqlClient;
using TechShop.Entities.Model;
using TechShop.Exceptions;

namespace TechShop.Services.dao.Reository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "INSERT INTO Customer (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address)";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Address", customer.Address);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Address", customer.Address);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CustomerID", id);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
                else
                {
                    throw new CustomerNotFoundException(id);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public decimal CalculateTotalOrders(int customerId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "SELECT SUM(TotalAmount) FROM [Order] WHERE CustomerID = @CustomerID";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
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
    }
}