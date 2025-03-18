using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public interface ICustomerOrderService
{
    Task<IEnumerable<CustomerOrderDto>> GetAll();
    Task<CustomerOrderDto> GetOrder(Guid id);
    Task<CustomerOrderDto> CreateCustomerOrder(CreateCustomerOrderRequest createCustomerOrder);
    Task<CustomerOrderDto> UpdateCustomerOrder(UpdateCustomerOrderRequest request);
    Task<bool> DeleteCustomerOrderAsync(Guid id);
}