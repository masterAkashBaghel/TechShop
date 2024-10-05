namespace TechShop.Entities.Model
{
    public class Product
    {
        private int _productID;
        private string? _productName;
        private string? _description;
        private decimal _price;
        private bool _inStock;
        public string Category { get; set; } // Add this property
        public Inventory Inventory { get; set; } // Add this property

        public int ProductID
        {
            get => _productID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ProductID must be positive.");
                _productID = value;
            }
        }

        public string ProductName
        {
            get => _productName;
            set => _productName = value ?? throw new ArgumentNullException(nameof(ProductName));
        }

        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(Description));
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                _price = value;
            }
        }

        public bool InStock
        {
            get => _inStock;
            set => _inStock = value;
        }

        public int QuantityInStock { get; set; }

    }
}