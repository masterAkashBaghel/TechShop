using TechShop.Entities.Model;
using System.Collections.Generic;

namespace TechShop.Services.dao.Reository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductDetails(int productID);
        void UpdateProductInfo(Product product);
        bool IsProductInStock(int productID);
    }
}