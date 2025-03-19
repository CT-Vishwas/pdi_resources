using VKKirana.Entities;
using VKKirana.Repositories;

namespace VKKirana.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public async Task<Customer> AddAsync(Customer customer)
        {
            _customers.Add(customer);
            return await Task.FromResult(customer ?? throw new InvalidOperationException("Customer not found"));
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await Task.FromResult(_customers);
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            return await Task.FromResult(customer ?? throw new InvalidOperationException("Customer not found"));
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await GetByIdAsync(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.CustomerEmail = customer.CustomerEmail;
                // Update other properties as needed
            }
        }
    }
}