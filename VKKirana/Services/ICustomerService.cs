using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(Guid customerId);
        Task<CustomerDto> AddCustomer(CreateCustomerRequest request);
        Task<CustomerDto> UpdateCustomer(CustomerDto customer);
        Task<bool> DeleteCustomer(Guid customerId);
    }
}