using ECommerce.Repositories;

namespace ECommerce.Services;
public interface IProductService
{
    IEnumerable<Product> GetAll();

    Product GetByCode(string code);

    Product GetByName(string name);

    IEnumerable<Product> GetByPrice(decimal priceMin, decimal priceMax);

    bool Add(Product product);

    void Patch(Product product, string code);

    Product Delete(string code);
}

public class DefaultProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public DefaultProductService(IProductRepository productRepository) => _productRepository = productRepository;

    public IEnumerable<Product> GetAll() => _productRepository.GetAll();

    public Product GetByCode(string code) => _productRepository.GetByCode(code);

    public Product GetByName(string name) => _productRepository.GetByName(name);

    public IEnumerable<Product> GetByPrice(decimal priceMin, decimal priceMax) => _productRepository.GetByPrice(priceMin, priceMax);

    public bool Add(Product product) => _productRepository.Add(product);

    public void Patch(Product product, string code) => _productRepository.Patch(product, code);

    public Product Delete(string code) => _productRepository.Delete(code);
}