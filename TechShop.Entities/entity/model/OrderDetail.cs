namespace TechShop.Entities.Model
{
    public class OrderDetail
    {
        private int _orderDetailID;
        private Order? _order;
        private Product? _product;
        private int _quantity;

        public int OrderDetailID
        {
            get => _orderDetailID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("OrderDetailID must be positive.");
                _orderDetailID = value;
            }
        }

        public Order Order
        {
            get => _order;
            set => _order = value ?? throw new ArgumentNullException(nameof(Order));
        }

        public Product Product
        {
            get => _product;
            set => _product = value ?? throw new ArgumentNullException(nameof(Product));
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity must be positive.");
                _quantity = value;
            }
        }
    }
}