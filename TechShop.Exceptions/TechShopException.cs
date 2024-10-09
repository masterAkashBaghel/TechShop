namespace TechShop.Exceptions
{
    public class TechShopException : Exception
    {
        public TechShopException(System.Runtime.Serialization.SerializationInfo info) { }

        public TechShopException(string message) : base(message) { }

        public TechShopException(string message, Exception innerException) : base(message, innerException) { }
    }
}