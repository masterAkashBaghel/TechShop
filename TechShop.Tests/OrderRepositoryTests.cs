using System.Data;
using Moq;
using NUnit.Framework;
using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private OrderRepository _orderRepository;
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();

            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);

            _orderRepository = new OrderRepository("fake_connection_string");
        }

        [Test]
        public void AddOrder_ShouldAddOrder()
        {
            var order = new Order
            {
                CustomerID = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 2000.00m
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            _orderRepository.PlaceOrder(order);

            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("INSERT INTO Orders")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }

        [Test]
        public void UpdateOrder_ShouldUpdateOrder()
        {
            var order = new Order
            {
                OrderID = 1,
                CustomerID = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 2000.00m
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            _orderRepository.UpdateOrder(order);

            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("UPDATE Orders")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }
    }
}