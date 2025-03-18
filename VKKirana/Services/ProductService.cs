using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Repositories;
namespace VKKirana.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;

    }

    public async Task<ProductDto> CreateProduct(CreateProductRequest createProduct)
    {
        var product = _mapper.Map<Product>(createProduct);
        await _productRepository.AddAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetProductsAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }

        _mapper.Map(request, product);
        await _productRepository.UpdateAsync(product);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id);
        if(product is null)
        {
            return false;
        }
        await _productRepository.DeleteAsync(id);
        return true;

    }
}