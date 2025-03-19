using System;

namespace VKKirana.Models.Requests;

public class CreateCustomerRequest
{
    public required string CustomerName { get; set;}

    public required string CustomerEmail { get; set;}

    public required string CustomerPhone {get; set;}

    public required string DeliveryAddress {get; set;}

}
