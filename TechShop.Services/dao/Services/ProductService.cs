using TechShop.Entities.Model;
using TechShop.Services.dao.Reository;

namespace TechShop.Services.dao.Services
{
    public class ProductService(IProductRepository productRepository) : IProductRepository
    {
        private readonly IProductRepository _productRepository = productRepository;

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product GetProductDetails(int productID)
        {
            return _productRepository.GetProductDetails(productID);
        }

        public void UpdateProductInfo(Product product)
        {
            _productRepository.UpdateProductInfo(product);
        }

        public bool IsProductInStock(int productID)
        {
            return _productRepository.IsProductInStock(productID);
        }
    }
}