using System;
using VKKirana.Models;
using VKKirana.Models.Requests;

namespace VKKirana.Services;

public class PaymentExternalService : IPaymentExternalService
{
    private readonly HttpClient _httpClient;
    public PaymentExternalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5172/");        
    }
    public async Task<PaymentDto> DoPayment(PaymentRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("payments", request);
        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<PaymentDto>() ?? new PaymentDto();
        }

        throw new HttpRequestException("Failed to do payment");
    }

    public Task<PaymentDto> PaymentDetails(Guid transactionId)
    {
        throw new NotImplementedException();
    }
}
