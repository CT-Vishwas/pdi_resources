using System;

namespace VKKirana.Models.Requests;

public class PaymentRequest
{
    public PaymentRequest(decimal totalAmount, string? currency, string? cardNumber, string expiryDate, string? cvv)
    {
        Amount = totalAmount;
        Currency = currency;
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        Cvv = cvv;
    }

    public decimal Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string Cvv { get; set; }


}
