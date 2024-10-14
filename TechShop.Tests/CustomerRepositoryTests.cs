using System.Data;
using Moq;
using NUnit.Framework;
using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Tests
{
    // Test class for the CustomerRepository class
    // Contains unit tests for the methods of the CustomerRepository class
    [TestFixture]
    public class CustomerRepositoryTests
    {
        // Private field of type CustomerRepository that stores the CustomerRepository object
        private CustomerRepository _customerRepository;
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;

        // Setup method that runs before each test method
        [SetUp]
        public void Setup()
        {
            // Initialize mock objects
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();

            // Setup mock behavior
            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);

            // Instantiate the CustomerRepository object
            _customerRepository = new CustomerRepository("fake_connection_string");
        }

        [Test]
        // Test method for the AddCustomer method
        public void AddCustomer_ShouldAddCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Address = "123 Main St"
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            // Act
            _customerRepository.AddCustomer(customer);

            // Assert
            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("INSERT INTO Customer")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }

        [Test]
        // Test method for the UpdateCustomer method
        public void UpdateCustomer_ShouldUpdateCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerID = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Address = "123 Main St"
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            // Act
            _customerRepository.UpdateCustomer(customer);

            // Assert
            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("UPDATE Customer")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }
    }
}