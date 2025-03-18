
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public interface IProductService
{
    Task<ProductDto> CreateProduct(CreateProductRequest createProduct);
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> GetById(Guid id);


    Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request);
    Task<bool> DeleteProductAsync(Guid id);
}