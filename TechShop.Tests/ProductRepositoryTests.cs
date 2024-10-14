using System.Data;
using Moq;
using NUnit.Framework;
using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();

            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);

            _productRepository = new ProductRepository("fake_connection_string");
        }

        [Test]
        public void AddProduct_ShouldAddProduct()
        {
            var product = new Product
            {
                ProductName = "Laptop",
                Description = "Gaming Laptop",
                Price = 1500.00m,
                Category = "Electronics",
                InStock = true
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            _productRepository.AddProduct(product);

            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("INSERT INTO Product")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }

        [Test]
        public void UpdateProduct_ShouldUpdateProduct()
        {
            var product = new Product
            {
                ProductID = 1,
                ProductName = "Laptop",
                Description = "Gaming Laptop",
                Price = 1500.00m,
                Category = "Electronics",
                InStock = true
            };

            _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

            _productRepository.UpdateProductInfo(product);

            _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("UPDATE Product")), Times.Once);
            _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        }
    }
}