
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid id);

    Task<ProductDto> CreateProduct(CreateProductRequest createProduct);

}