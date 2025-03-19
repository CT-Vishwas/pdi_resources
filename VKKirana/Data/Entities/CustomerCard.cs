using System;
using System.ComponentModel.DataAnnotations;

namespace VKKirana.Entities;

public class CustomerCard
{
    [Key]
    public Guid CardId { get; set;}

    public string CardNumber {get; set;}

    public string ExpiryMonth { get; set;}

    public string ExpiryYear { get; set;}
    public string Currency { get; set;}

    public string Cvv { get; set;}

}
