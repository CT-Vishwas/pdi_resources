using System;

namespace paymentApp.Data;

public class PaymentStatusResponse
{
    public Guid TransactionId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; } = "Success";

}
