using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public interface ICustomerOrderService
{
    Task<IEnumerable<CustomerOrderDto>> GetCustomerOrdersAsync();
    Task<CustomerOrderDto> GetCustomerOrderByIdAsync(Guid id);
    Task<CustomerOrderDto> CreateCustomerOrder(CreateCustomerOrderRequest createCustomerOrder);
}