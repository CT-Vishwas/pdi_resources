using System.Collections.Generic;
using System.Threading.Tasks;
using VKKirana.Data.Entities;

namespace VKKirana.Data.Repositories
{
    public interface ICustomerOrderRepository
    {
        Task<IEnumerable<CustomerOrder>> GetAllOrdersAsync();
        Task<CustomerOrder> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(CustomerOrder order);
        Task UpdateOrderAsync(CustomerOrder order);
        Task DeleteOrderAsync(int orderId);
    }
}