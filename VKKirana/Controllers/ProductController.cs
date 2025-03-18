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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productService.CreateProduct(request);
        if (result == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Creation Failed", null));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ProductDto>(true, "Product Created Successfully", result));
    }

    // Get List of Products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetProductsAsync();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result));
    }

    // Get a Product by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Fetched Successfully", result));
    }

    // Update a Product
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
    {
        var result = await _productService.UpdateProductAsync(id, request);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Updated Successfully", result));
    }

    // Delete a Product
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        if (!result)
        {
            return NotFound(new ApiResponse<bool>(false, "Product Not Found", false));
        }
        return Ok(new ApiResponse<bool>(true, "Product Deleted Successfully", true));
    }
}