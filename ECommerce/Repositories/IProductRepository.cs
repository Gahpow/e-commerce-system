namespace ECommerce.Repositories;

public interface IProductRepository
{   
    public List<Product> GetAll();
}


public class DefaultProductRepository : IProductRepository
{
    private List<Product> MockProductList = new List<Product>() { 
        new Product() { ProductCode = "1", ProductDescription = "firstSample", ProductName = "sample", ProductPrice = 5m, ProductQuantity = 15 },
        new Product() { ProductCode = "2", ProductDescription = "secondSample", ProductName = "sampleTwo", ProductPrice = 10m, ProductQuantity = 4 },
    };

    public List<Product> GetAll()
    {
        return MockProductList;
    }

}