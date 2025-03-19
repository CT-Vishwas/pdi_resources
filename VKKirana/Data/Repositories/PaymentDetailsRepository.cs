using System;
using VKKirana.Data.Entities;
using VKKirana.Repositories;

namespace VKKirana.Data.Repositories;

public class PaymentDetailsRepository: IPaymentDetailsRepository
{
    private readonly AppDbContext _context;

    public PaymentDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentDetails> AddAsync(PaymentDetails paymentDetails)
    {
        await _context.PaymentDetails.AddAsync(paymentDetails);
        await _context.SaveChangesAsync();
        return paymentDetails;
    }
}
