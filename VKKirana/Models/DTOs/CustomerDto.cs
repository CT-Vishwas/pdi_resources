using System;

namespace VKKirana.Models.DTOs;

public class CustomerDto
{
    public Guid CustomerId;
    public required string CustomerName { get; set;}

    public required string CustomerEmail { get; set;}

    public required string CustomerPhone {get; set;}

    public required string DeliveryAddress {get; set;}

}
