using Microsoft.AspNetCore.Mvc;
using VKKirana.Models;
using VKKirana.Services;

namespace VKKirana.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    public ProductController()
    {

    }

    // Adding a Product
    [HttpPost]
    public IActionResult Create(Product product)
    {
        ProductService.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // Get List of Products
    [HttpGet]
    public ActionResult<List<Product>> GetAll() => ProductService.GetAll();

    // Get a single Product
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = ProductService.Get(id);

        if (product is null)
            return NotFound();

        return product;
    }

    // Update a Product
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        var exsitingProduct = ProductService.Get(id);
        if (exsitingProduct is null)
            return NotFound();

        ProductService.Update(product);

        return NoContent();
    }


    // Delete a Prduct
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = ProductService.Get(id);

        if (product is null)
        {
            return NotFound();
        }

        ProductService.Delete(id);
        return NoContent();
    }
}