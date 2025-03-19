namespace VKKirana.Entities;

public class Customer
{
    public Guid CustomerId;
    public required string CustomerName { get; set;}

    public required string CustomerEmail { get; set;}

    public required string CustomerPhone {get; set;}

    public required string DeliveryAddress {get; set;}

    public required CustomerCard CustomerCard { get; set;}
}
