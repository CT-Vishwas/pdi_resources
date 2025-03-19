using VKKirana.Entities;

namespace VKKirana.Repositories;
public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task DeleteAsync(Guid id);
    Task<Customer> GetByIdAsync(Guid id);
    Task UpdateAsync(Customer customer);
}