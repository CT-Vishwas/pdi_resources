using System;
using AutoMapper;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;

namespace VKKirana.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<CreateCustomerOrderRequest, CustomerOrder>();
        CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap();
        CreateMap<OrderItem, Product>().ReverseMap();
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<CustomerDto, Customer>().ReverseMap();
    }

}
