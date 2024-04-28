using Microsoft.AspNetCore.Mvc;
using ECommerce.Services;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet("GetAllProducts")]
    public List<Product> Get([FromServices] IProductService productService)
    {
        return productService.GetAll();
    }

}