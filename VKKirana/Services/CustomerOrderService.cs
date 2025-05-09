using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKKirana.Data.Entities;
using VKKirana.Data.Repositories;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Repositories;

namespace VKKirana.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly ICustomerOrderRepository _customerOrderRepository;

    private readonly ICustomerRepository _customerRepository;

    private readonly IPaymentDetailsRepository _paymentDetailsRepository;

    private readonly IPaymentExternalService _paymentService;
    private readonly IMapper _mapper;

    public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, IMapper mapper, IPaymentExternalService payment, ICustomerRepository customerRepository, IPaymentDetailsRepository paymentDetailsRepository)
    {
        _customerOrderRepository = customerOrderRepository;
        _mapper = mapper;
        _paymentService = payment;
        _customerRepository = customerRepository;
        _paymentDetailsRepository = paymentDetailsRepository;
    }


    public async Task<CustomerOrderDto> CreateCustomerOrder(CreateCustomerOrderRequest createCustomerOrder)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(createCustomerOrder);
        await _customerOrderRepository.AddOrderAsync(customerOrder);
        var customerOrderDto = _mapper.Map<CustomerOrderDto>(customerOrder);

        var customer = await _customerRepository.GetByIdAsync(createCustomerOrder.CustomerId);
        var customerCard = customer?.CustomerCard;

        var paymentRequest = new PaymentRequest(
            customerOrder.TotalAmount,
            customerCard?.Currency,
            customerCard?.CardNumber,
            customerCard?.ExpiryMonth + "/"+customerCard?.ExpiryYear,
            customerCard?.Cvv
        );
        var payment = await _paymentService.DoPayment(paymentRequest);
        var paymentDetails = new PaymentDetails(
            payment.TransactionId,
            customer.CustomerId,
            payment.Status,
            customerOrder.TotalAmount
        );
        var savedDetails = await _paymentDetailsRepository.AddAsync(paymentDetails);

        if( savedDetails == null)
        {
            throw new ApplicationException("Failed to update payment details");
        }

        return customerOrderDto;
    }

    public async Task<bool> DeleteCustomerOrderAsync(Guid id)
    {
        var existingOrder = await _customerOrderRepository.GetOrderByIdAsync(id);
        if (existingOrder == null)
        {
            return false;
        }

        await _customerOrderRepository.DeleteOrderAsync(id);
        return true;
    }

    public async Task<IEnumerable<CustomerOrderDto>> GetAll()
    {
        var customerOrders = await _customerOrderRepository.GetAllOrdersAsync();
        var customerOrderDtos = _mapper.Map<IEnumerable<CustomerOrderDto>>(customerOrders);
        return customerOrderDtos;
    }

    public async Task<CustomerOrderDto> GetOrder(Guid id)
    {
        var customerOrder = await _customerOrderRepository.GetOrderByIdAsync(id);
        if (customerOrder == null)
        {
            throw new KeyNotFoundException("Customer order not found");
        }
        var customerOrderDto = _mapper.Map<CustomerOrderDto>(customerOrder);
        return customerOrderDto;
    }



    public async Task<CustomerOrderDto> UpdateCustomerOrder(UpdateCustomerOrderRequest request)
    {
        var existingOrder = await _customerOrderRepository.GetOrderByIdAsync(request.OrderId);
        if (existingOrder == null)
        {
            throw new KeyNotFoundException("Customer order not found");
        }

        _mapper.Map(request, existingOrder);
        await _customerOrderRepository.UpdateOrderAsync(existingOrder);

        var updatedOrderDto = _mapper.Map<CustomerOrderDto>(existingOrder);
        return updatedOrderDto;
    }
}