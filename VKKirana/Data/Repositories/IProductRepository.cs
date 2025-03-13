

using VKKirana.Entities;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task AddAsync(Product product);
    Task Update(Product product);
    Task DeleteAsync(Guid id);
}