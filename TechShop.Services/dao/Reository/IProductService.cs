

using TechShop.Entities.Model;
using System.Collections.Generic;


namespace TechShop.Services.DAO
{
    public interface IProducts
    {
        void AddProduct(Product product);

        Product GetProductDetails(int productID);
        void UpdateProductInfo(Product product);
        bool IsProductInStock(int productID);
    }
}