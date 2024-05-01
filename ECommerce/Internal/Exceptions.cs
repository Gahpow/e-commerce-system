namespace ECommerce.Exceptions;

public class Exceptions
{
    public class ProductValidationException : Exception 
    {
        public static ProductValidationException New(string message) { return new ProductValidationException(message); }

        private ProductValidationException(string message) : base(message) { }
    }

    public class ProductNotFoundException : Exception 
    {
        public static ProductNotFoundException New(string message) { return new ProductNotFoundException(message); }

        public static ProductNotFoundException New() { return new ProductNotFoundException("Product not found"); }

        private ProductNotFoundException(string message) : base(message) { }
    }
}