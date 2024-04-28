using ECommerce.Repositories;

namespace ECommerce.Services;
public interface IProductService
{
    List<Product> GetAll(); 
}

public class DefaultProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public DefaultProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAll()
    {
        return _productRepository.GetAll();
    }
}