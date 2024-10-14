using System.Data;
using Moq;
using NUnit.Framework;
using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Tests
{
    [TestFixture]
    public class InventoryRepositoryTests
    {
        private InventoryRepository _inventoryRepository;
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();

            _mockConnection.Setup(conn => conn.CreateCommand()).Returns(_mockCommand.Object);

            _inventoryRepository = new InventoryRepository("fake_connection_string");
        }

        // [Test]
        // public void AddInventory_ShouldAddInventory()
        // {
        //     var inventory = new Inventory
        //     {
        //         ProductID = 1,
        //         QuantityInStock = 100
        //     };

        //     _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

        //     _inventoryRepository.AddToInventory(inventory);

        //     _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("INSERT INTO Inventory")), Times.Once);
        //     _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        // }

        // [Test]
        // public void UpdateInventory_ShouldUpdateInventory()
        // {
        //     var inventory = new Inventory
        //     {
        //         InventoryID = 1,
        //         ProductID = 1,
        //         QuantityInStock = 100
        //     };

        //     _mockCommand.Setup(cmd => cmd.ExecuteNonQuery()).Returns(1);

        //     _inventoryRepository.AddToInventory(inventory);

        //     _mockCommand.VerifySet(cmd => cmd.CommandText = It.Is<string>(s => s.Contains("UPDATE Inventory")), Times.Once);
        //     _mockCommand.Verify(cmd => cmd.ExecuteNonQuery(), Times.Once);
        // }
    }
}