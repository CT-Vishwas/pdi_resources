using System.Collections.Generic;
using System.Threading.Tasks;
using VKKirana.Entities;

namespace VKKirana.Repositories
{
    public interface ICustomerOrderRepository
    {
        Task<IEnumerable<CustomerOrder>> GetAllOrdersAsync();
        Task<CustomerOrder> GetOrderByIdAsync(Guid orderId);
        Task AddOrderAsync(CustomerOrder order);
        Task UpdateOrderAsync(CustomerOrder order);
        Task DeleteOrderAsync(Guid orderId);
    }
}