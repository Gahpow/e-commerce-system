using static ECommerce.Exceptions.Exceptions;

using Microsoft.AspNetCore.Mvc;
using ECommerce.Services;
using ECommerce.Extensions;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet("all")]
    public IEnumerable<Product> Get([FromServices] IProductService productService) => productService.GetAll();

    [HttpGet("code/{code}")]
    public ActionResult GetByCode([FromServices] IProductService productService, string code)
    {
        try
        {
            var product = productService.GetByCode(code.ValidateCode());
            return Ok(product);
        } 
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
        catch (ProductNotFoundException exception)
        {
            return StatusCode(404, exception.Message);
        }
    }

    [HttpGet("name/{name}")]
    public ActionResult GetByName([FromServices] IProductService productService, string name)
    {
        try
        {
            var product = productService.GetByName(name.ValidateName());
            return Ok(product);
        }
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
        catch (ProductNotFoundException exception)
        {
            return StatusCode(404, exception.Message);
        }
    }

    [HttpGet("{priceMin}&{priceMax}")]
    public ActionResult GetByPrice([FromServices] IProductService productService, decimal priceMin, decimal priceMax)
    {
        try
        {
            Extensions.Extensions.ValidatePrices(priceMin, priceMax);
            var productList = productService.GetByPrice(priceMin.ValidatePrice(), priceMax.ValidatePrice());
            return Ok(productList);
        }
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
        catch (ProductNotFoundException exception)
        {
            return StatusCode(404, exception.Message);
        }
    }

    [HttpPost]
    public ActionResult Add([FromServices] IProductService productService, [FromBody] Product product)
    {
        try
        {
            productService.Add(product.ValidateProduct());
            return StatusCode(201);
        }
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
    }

    [HttpPut]
    public ActionResult Patch([FromServices] IProductService productService, [FromBody] Product product, string code)
    {
        try
        {
            productService.Patch(product.ValidateProduct(), code.ValidateCode());
            return StatusCode(200);
        }
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
    }

    [HttpDelete("{code}")]
    public ActionResult Delete([FromServices] IProductService productService, string code)
    {
        try
        {
            productService.Delete(code.ValidateCode());
            return StatusCode(204);
        }
        catch (ProductValidationException exception)
        {
            return StatusCode(422, exception.Message);
        }
        catch (ProductNotFoundException exception)
        {
            return StatusCode(404, exception.Message);
        }
    }
}