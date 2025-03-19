using System;
using System.ComponentModel.DataAnnotations;

namespace paymentApp.Data;

public class Payment
{
    [Key]
    public Guid TransactionId { get; set; }
    public string PaymentStatus { get; set; }
    public string Message { get; set; } = "Success";
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string Cvv { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
