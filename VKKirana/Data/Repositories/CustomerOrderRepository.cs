using Microsoft.EntityFrameworkCore;
using VKKirana.Data;
using VKKirana.Entities;

namespace VKKirana.Repositories;
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly AppDbContext _context;

        public CustomerOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllOrdersAsync()
        {
            return await _context.CustomerOrders.ToListAsync();
        }

        public async Task<CustomerOrder> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.CustomerOrders.FindAsync(orderId);
        }

        public async Task AddOrderAsync(CustomerOrder order)
        {
            await _context.CustomerOrders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(CustomerOrder order)
        {
            _context.CustomerOrders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            var order = await _context.CustomerOrders.FindAsync(orderId);
            if (order != null)
            {
                _context.CustomerOrders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
}