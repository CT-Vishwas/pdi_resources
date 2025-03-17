using Microsoft.AspNetCore.Mvc;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Models.Responses;
using VKKirana.Services;

namespace VKKirana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // Adding a Product
    [HttpPost]
    public async Task<ActionResult<ApiResponse<ProductDto>>> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productService.CreateProduct(request);
        return new ApiResponse<ProductDto>(true, "Product Created Successfully", result);
    }

    // Get List of Products
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetAll()
    {
        var result = await _productService.GetProductsAsync();
        return new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result);

    }

    // Get a single Product
    // [HttpGet("{id}")]
    // public ActionResult<Product> Get(int id)
    // {
    //     var product = ProductService.Get(id);

    //     if (product is null)
    //         return NotFound();

    //     return product;
    // }

    // Update a Product
    // [HttpPut("{id}")]
    // public IActionResult Update(int id, Product product)
    // {
    //     if (id != product.Id)
    //         return BadRequest();

    //     var exsitingProduct = ProductService.Get(id);
    //     if (exsitingProduct is null)
    //         return NotFound();

    //     ProductService.Update(product);

    //     return NoContent();
    // }


    // Delete a Prduct
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     var product = ProductService.Get(id);

    //     if (product is null)
    //     {
    //         return NotFound();
    //     }

    //     ProductService.Delete(id);
    //     return NoContent();
    // }
}