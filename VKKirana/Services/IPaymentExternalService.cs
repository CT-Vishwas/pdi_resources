using System;
using VKKirana.Models;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public interface IPaymentExternalService
{
    Task<PaymentDto> DoPayment(PaymentRequest request);
    Task<PaymentDto> PaymentDetails(Guid transactionId);

}
