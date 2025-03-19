using System;
using VKKirana.Data.Entities;

namespace VKKirana.Repositories;

public interface IPaymentDetailsRepository
{
    Task<PaymentDetails> AddAsync(PaymentDetails paymentDetails);

}
