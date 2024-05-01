using static ECommerce.Exceptions.Exceptions;

namespace ECommerce.Repositories;

public interface IProductRepository
{
    public IEnumerable<Product> GetAll();

    public Product GetByCode(string code);

    public Product GetByName(string name);

    public IEnumerable<Product> GetByPrice(decimal priceMin, decimal priceMax);

    public bool Add(Product product);

    public void Patch(Product product, string code);

    public Product Delete(string code);
}


public class DefaultProductRepository : IProductRepository
{
    private List<Product> MockProductList = new List<Product>() {
        new Product() { ProductCode = "A1234567", ProductDescription = "firstSample", ProductName = "sample", ProductPrice = 5m, ProductQuantity = 15 },
        new Product() { ProductCode = "B1234567", ProductDescription = "secondSample", ProductName = "sampleTwo", ProductPrice = 10m, ProductQuantity = 4 },
    };

    public IEnumerable<Product> GetAll() => MockProductList;

    public Product GetByCode(string code)
    {
        var product = MockProductList.FirstOrDefault(x => x.ProductCode == code);
        if (product == null)
        {
            throw ProductNotFoundException.New();
        }
        return product;
    }

    public Product GetByName(string name)
    {
        var product = MockProductList.FirstOrDefault(x => x.ProductName == name);
        if (product == null)
        {
            throw ProductNotFoundException.New();
        }
        return product;
    }

    public IEnumerable<Product> GetByPrice(decimal priceMin, decimal priceMax)
    {
        var products = MockProductList.Where(x => x.ProductPrice > priceMin && x.ProductPrice <= priceMax);
        if (!products.Any())
        {
            throw ProductNotFoundException.New();
        }
        return products;
    }

    public bool Add(Product product) {
        MockProductList.Add(product);
        return true;
    }

    public void Patch(Product product, string code)
    {
        int index = MockProductList.FindIndex(x => x.ProductCode == code);
        if (index == -1)
        {
            MockProductList.Add(product);
        }
        else
        {
            MockProductList[index] = product;
        }
    }

    public Product Delete(string code)
    {
        int index = MockProductList.FindIndex(x => x.ProductCode == code);
        if (index == -1)
        {
            throw ProductNotFoundException.New();
        }
        else
        {
            var deletedProduct = MockProductList[index];
            MockProductList.RemoveAt(index);
            return deletedProduct;
        }
    }
}