using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Entities;

namespace VendingMachine.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ColumnId }, product);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.ColumnId)
        {
            return BadRequest();
        }

        _productService.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        _productService.DeleteProduct(id);
        return Ok();
    }
}
