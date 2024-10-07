using TechShop.Entities.Model;

namespace TechShop.Services.dao.Reository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product GetProductDetails(int productID)
        {
            return products.FirstOrDefault(p => p.ProductID == productID)!;
        }

        public void UpdateProductInfo(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct == null)
                throw new ArgumentException("Product not found.");

            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Description = product.Description;
        }

        public bool IsProductInStock(int productID)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productID);
            return product != null && product.Inventory.QuantityInStock > 0;
        }
    }
}