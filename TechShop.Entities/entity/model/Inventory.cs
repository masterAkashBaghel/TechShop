using System;

namespace TechShop.Entities.Model
{
    public class Inventory
    {
        private int _inventoryID;
        private Product _product;
        private int _quantityInStock;
        private DateTime _lastStockUpdate;

        public int InventoryID
        {
            get => _inventoryID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("InventoryID must be positive.");
                _inventoryID = value;
            }
        }

        public Product Product
        {
            get => _product;
            set => _product = value ?? throw new ArgumentNullException(nameof(Product));
        }

        public int QuantityInStock
        {
            get => _quantityInStock;
            set
            {
                if (value < 0)
                    throw new ArgumentException("QuantityInStock cannot be negative.");
                _quantityInStock = value;
            }
        }

        public DateTime LastStockUpdate
        {
            get => _lastStockUpdate;
            set => _lastStockUpdate = value;
        }
    }
}