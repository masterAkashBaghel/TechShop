using System;

namespace TechShop.Entities.Model
{
    public class Order
    {
        private int _orderID;
        private Customer? _customer;
        private DateTime _orderDate;
        private decimal _totalAmount;

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();


        public int OrderID
        {
            get => _orderID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("OrderID must be positive.");
                _orderID = value;
            }
        }

        public Customer Customer
        {
            get => _customer;
            set => _customer = value ?? throw new ArgumentNullException(nameof(Customer));
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("TotalAmount cannot be negative.");
                _totalAmount = value;
            }
        }

        public object CustomerID { get; set; }
        public string Status { get; set; }


    }
}