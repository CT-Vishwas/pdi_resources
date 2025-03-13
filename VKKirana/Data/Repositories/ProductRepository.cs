using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKKirana.Data;
using VKKirana.Entities;


public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public Product GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }

    Task IProductRepository.AddAsync(Product product)
    {
        return AddAsync(product);
    }

    Task<IEnumerable<Product>> IProductRepository.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Product> IProductRepository.GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}