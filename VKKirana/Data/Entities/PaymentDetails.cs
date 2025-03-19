using System;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace VKKirana.Data.Entities;

public class PaymentDetails
{
    
    public Guid TransactionId { get; set; } 
    public Guid CustomerId {get; set;}

    public string PaymentStatus;

    public decimal Amount;

    public PaymentDetails(Guid transactionId, Guid customerId, string paymentStatus, decimal amount)
    {
        TransactionId = transactionId;
        CustomerId= customerId;
        PaymentStatus = paymentStatus;
        Amount = amount;
        
    }

}
