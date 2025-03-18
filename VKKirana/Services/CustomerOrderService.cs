using AutoMapper;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Data.Repositories;

namespace VKKirana.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly ICustomerOrderRepository _customerOrderRepository;
    private readonly IMapper _mapper;

    public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, IMapper mapper)
    {
        _customerOrderRepository = customerOrderRepository;
        _mapper = mapper;
    }

    public async Task<CustomerOrderDto> CreateCustomerOrder(CreateCustomerOrderRequest createCustomerOrder)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(createCustomerOrder);
        await _customerOrderRepository.AddAsync(customerOrder);
        var customerOrderDto = _mapper.Map<CustomerOrderDto>(customerOrder);
        return customerOrderDto;
    }

    public async Task<CustomerOrderDto> GetCustomerOrderByIdAsync(Guid id)
    {
        var customerOrder = await _customerOrderRepository.GetByIdAsync(id);
        if (customerOrder == null)
        {
            throw new KeyNotFoundException("Customer order not found");
        }
        var customerOrderDto = _mapper.Map<CustomerOrderDto>(customerOrder);
        return customerOrderDto;
    }

    public async Task<IEnumerable<CustomerOrderDto>> GetCustomerOrdersAsync()
    {
        var customerOrders = await _customerOrderRepository.GetAll();
        var customerOrderDtos = _mapper.Map<IEnumerable<CustomerOrderDto>>(customerOrders);
        return customerOrderDtos;
    }
}