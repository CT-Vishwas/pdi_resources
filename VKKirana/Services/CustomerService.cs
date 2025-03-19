using System.Collections.Generic;
using AutoMapper;
using VKKirana.Data.Repositories;
using VKKirana.Entities;
using VKKirana.Models.DTOs;
using VKKirana.Models.Requests;
using VKKirana.Repositories;

namespace VKKirana.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> AddCustomer(CreateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            var addedCustomer = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerDto>(addedCustomer);
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
            return true;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerById(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.UpdateAsync(customer);
            return customerDto;
        }
    }
}