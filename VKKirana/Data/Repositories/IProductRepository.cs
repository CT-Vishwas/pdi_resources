using VKKirana.Entities;

namespace VKKirana.Repositories;
 public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task DeleteAsync(Guid id);
        Task<Product> GetByIdAsync(Guid id);
        Task UpdateAsync(Product product);
    }