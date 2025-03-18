using Microsoft.AspNetCore.Mvc;
using VKKirana.Data.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Models.Responses;
using VKKirana.Services;
using VKKirana.Data.Repositories;

namespace VKKirana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerOrderController : ControllerBase
{
    private readonly ICustomerOrderService _customerOrderService;

    public CustomerOrderController(ICustomerOrderService customerOrderService)
    {
        _customerOrderService = customerOrderService;
    }

    // Adding a Customer Order
    [HttpPost]
    public async Task<ActionResult<ApiResponse<CustomerOrderDto>>> CreateCustomerOrder([FromBody] CreateCustomerOrderRequest request)
    {
        var result = await _customerOrderService.CreateCustomerOrder(request);
        return new ApiResponse<CustomerOrderDto>(true, "Customer Order Created Successfully", result);
    }

    // Get List of Customer Orders
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<CustomerOrderDto>>>> GetAll()
    {
        var result = await _customerOrderService.GetCustomerOrdersAsync();
        return new ApiResponse<IEnumerable<CustomerOrderDto>>(true, "Customer Orders Fetched Successfully", result);
    }

    // Get a single Customer Order
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CustomerOrderDto>>> Get(int id)
    {
        var result = await _customerOrderService.GetCustomerOrderByIdAsync(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<CustomerOrderDto>(false, "Customer Order Not Found", null));
        }
        return new ApiResponse<CustomerOrderDto>(true, "Customer Order Fetched Successfully", result);
    }

    // Update a Customer Order
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerOrderRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest(new ApiResponse<CustomerOrderDto>(false, "Invalid Customer Order Id", null));
        }

        var result = await _customerOrderService.UpdateCustomerOrderAsync(request);
        if (result == null)
        {
            return NotFound(new ApiResponse<CustomerOrderDto>(false, "Customer Order Not Found", null));
        }

        return Ok(new ApiResponse<CustomerOrderDto>(true, "Customer Order Updated Successfully", result));
    }

    // Delete a Customer Order
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _customerOrderService.DeleteCustomerOrderAsync(id);
        if (!result)
        {
            return NotFound(new ApiResponse<bool>(false, "Customer Order Not Found", false));
        }

        return Ok(new ApiResponse<bool>(true, "Customer Order Deleted Successfully", true));
    }
}