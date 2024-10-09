using System;
using System.Runtime.Serialization;

namespace TechShop.Exceptions
{

    public class CustomerNotFoundException : TechShopException
    {
        public int CustomerId { get; }

        public CustomerNotFoundException(int customerId)
            : base($"Customer with ID {customerId} was not found.")
        {
            CustomerId = customerId;
        }

        public CustomerNotFoundException(int customerId, Exception innerException)
            : base($"Customer with ID {customerId} was not found.", innerException)
        {
            CustomerId = customerId;
        }
    }


    public class OrderNotFoundException : TechShopException
    {
        public int OrderId { get; }

        public OrderNotFoundException(int orderId)
            : base($"Order with ID {orderId} was not found.")
        {
            OrderId = orderId;
        }

        public OrderNotFoundException(int orderId, Exception innerException)
            : base($"Order with ID {orderId} was not found.", innerException)
        {
            OrderId = orderId;
        }


    }


    public class ProductNotFoundException : TechShopException
    {
        public int ProductId { get; }

        public ProductNotFoundException(int productId)
            : base($"Product with ID {productId} was not found.")
        {
            ProductId = productId;
        }

        public ProductNotFoundException(int productId, Exception innerException)
            : base($"Product with ID {productId} was not found.", innerException)
        {
            ProductId = productId;
        }




    }


    public class InventoryItemNotFoundException : TechShopException
    {
        public int InventoryItemId { get; }

        public InventoryItemNotFoundException(int inventoryItemId)
            : base($"Inventory item with ID {inventoryItemId} was not found.")
        {
            InventoryItemId = inventoryItemId;
        }

        public InventoryItemNotFoundException(int inventoryItemId, Exception innerException)
            : base($"Inventory item with ID {inventoryItemId} was not found.", innerException)
        {
            InventoryItemId = inventoryItemId;
        }


    }


    public class OrderDetailNotFoundException : TechShopException
    {
        public int OrderDetailID { get; }

        public OrderDetailNotFoundException(int orderDetailID)
            : base($"OrderDetail with ID {orderDetailID} was not found.")
        {
            OrderDetailID = orderDetailID;
        }

        public OrderDetailNotFoundException(int orderDetailID, Exception innerException)
            : base($"OrderDetail with ID {orderDetailID} was not found.", innerException)
        {
            OrderDetailID = orderDetailID;
        }
    }
}
