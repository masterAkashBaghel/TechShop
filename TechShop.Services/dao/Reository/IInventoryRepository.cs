using TechShop.Entities.Model;
namespace TechShop.Services.dao.Reository
{
    public interface IInventoryRepository
    {
        void AddToInventory(Product product);
        void RemoveFromInventory(Product product);
        void UpdateStockQuantity(Product product, int newQuantity);
        bool IsProductAvailable(Product product, int quantityToCheck);
        double GetInventoryValue();
        List<Product> ListLowStockProducts(int threshold);
        List<Product> ListOutOfStockProducts();
        Product GetProduct(int productID);
        int GetQuantityInStock(int productID);
    }
}