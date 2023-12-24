using Microsoft.AspNetCore.Mvc;
using ORMEntity.ProductOperations.CreateProduct;
using ORMEntity.ProductOperations.UpdateProduct;
using ProductManage.Services;

namespace ProductManage.Controllers;

// The ProductController class handles HTTP requests related to product operations.
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductServices _productService;

    public ProductController(IProductServices productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        try
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var productById = _productService.GetProductById(id);
        if (productById == null)
        {
            return NotFound();
        }

        return Ok(productById);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductModel newProduct)
    {
        try
        {
            if (string.IsNullOrEmpty(newProduct.Name) || newProduct.Price < 0)
            {
                return BadRequest("Name and Price are required fields.");
            }

            _productService.CreateProduct(newProduct);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Name }, newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updatedProduct)
    {
        try
        {
            _productService.UpdateProduct(id, updatedProduct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}