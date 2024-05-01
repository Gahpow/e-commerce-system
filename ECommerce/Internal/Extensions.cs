using static ECommerce.Exceptions.Exceptions;

namespace ECommerce.Extensions;

public static class Extensions
{
    public static string ValidateCode(this string code)
    {
        if (code.Length != 8)
        {
            throw ProductValidationException.New("Code length is incorrect");
        }
        return code;
    }

    public static string ValidateName(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw ProductValidationException.New("Name cannot be empty");
        }
        return name;
    }

    public static decimal ValidatePrice(this decimal price)
    {
        if (price < 0)
        {
            throw ProductValidationException.New("Price cannot be negative");
        }
        return price;
    }

    public static Product ValidateProduct(this Product product)
    {
        if (product == null)
        {
            throw ProductValidationException.New("Product cannot be null");
        }
        if (product.ProductQuantity < 0)
        {
            throw ProductValidationException.New("Quantity cannot be negative");
        }
        if (string.IsNullOrWhiteSpace(product.ProductDescription))
        {
            throw ProductValidationException.New("Description cannot be empty");
        }
        product.ProductCode.ValidateCode();
        product.ProductName.ValidateName();
        product.ProductPrice.ValidatePrice();

        return product;
    }

    public static void ValidatePrices(decimal priceMin, decimal priceMax)
    {
        if (priceMin > priceMax)
        {
            throw ProductValidationException.New("Minimum price cannot be bigger than maximum price");
        }
    }
}