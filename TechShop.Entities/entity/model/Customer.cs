using System.Collections.Generic;

namespace TechShop.Entities.Model
{
    public class Customer
    {
        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _address;
        private List<Order> _orders;

        public int CustomerID
        {
            get => _customerID;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("CustomerID must be positive.");
                _customerID = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentNullException(nameof(FirstName));
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentNullException(nameof(LastName));
        }

        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException(nameof(Email));
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value ?? throw new ArgumentNullException(nameof(Phone));
        }

        public string Address
        {
            get => _address;
            set => _address = value ?? throw new ArgumentNullException(nameof(Address));
        }

        public List<Order> Orders
        {
            get => _orders;
            set => _orders = value ?? throw new ArgumentNullException(nameof(Orders));
        }

        public Customer()
        {
            _orders = new List<Order>();
        }
    }
}