using System;

namespace VKKirana.Models;

public class PaymentDto
{
    public Guid TransactionId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; } = "Success";

}
