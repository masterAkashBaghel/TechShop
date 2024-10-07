using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Services.dao.Services
{
    public class InventoryService(IInventoryRepository inventoryRepository) : IInventoryRepository
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

        public void AddToInventory(Product product)
        {
            _inventoryRepository.AddToInventory(product);
        }

        public void RemoveFromInventory(Product product)
        {
            _inventoryRepository.RemoveFromInventory(product);
        }

        public void UpdateStockQuantity(Product product, int newQuantity)
        {
            _inventoryRepository.UpdateStockQuantity(product, newQuantity);
        }

        public bool IsProductAvailable(Product product, int quantityToCheck)
        {
            return _inventoryRepository.IsProductAvailable(product, quantityToCheck);
        }

        public double GetInventoryValue()
        {
            return _inventoryRepository.GetInventoryValue();
        }

        public List<Product> ListLowStockProducts(int threshold)
        {
            return _inventoryRepository.ListLowStockProducts(threshold);
        }

        public List<Product> ListOutOfStockProducts()
        {
            return _inventoryRepository.ListOutOfStockProducts();
        }

        public Product GetProduct(int productID)
        {
            return _inventoryRepository.GetProduct(productID);
        }

        public int GetQuantityInStock(int productID)
        {
            return _inventoryRepository.GetQuantityInStock(productID);
        }
    }
}