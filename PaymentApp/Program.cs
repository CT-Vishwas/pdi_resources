using Microsoft.EntityFrameworkCore;
using paymentApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(9, 2, 0)))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/payments", async (PaymentRequest request, AppDbContext dbContext) =>
{
    if(request.Amount <= 0)
    {
        return Results.BadRequest("Amount should be greater than 0");
    }

    var transactionId = Guid.NewGuid();
    var status = "SUCCESS";
    var message = "Payment processed successfully";

    try
    {
        await dbContext.Payments.AddAsync(new Payment
        {
            TransactionId = transactionId,
            Amount = request.Amount,
            Currency = request.Currency,
            CardNumber = request.CardNumber,
            ExpiryDate = request.ExpiryDate,
            Cvv = request.Cvv,
            PaymentStatus = "SUCCESS",
        });

        await dbContext.SaveChangesAsync();
        var response = new PaymentResponse
        {
            TransactionId = transactionId,
            Status = status,
            Message = message
        };

        return Results.Created($"/payments/{transactionId}", response);

    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("ProcessPayment")
.WithOpenApi();


app.MapGet("/payments/{transactionId}", async (Guid transactionId, AppDbContext dbContext) =>
{
    var payment = await dbContext.Payments.FirstOrDefaultAsync(p => p.TransactionId == transactionId);

    if(payment == null)
    {
        return Results.NotFound();
    }

    var response = new Payment
    {
        TransactionId = payment.TransactionId,
        PaymentStatus = payment.PaymentStatus,
        Message = payment.Message,
        Amount = payment.Amount,
        Currency = payment.Currency,
        CardNumber = payment.CardNumber,
        ExpiryDate = payment.ExpiryDate,
        Cvv = payment.Cvv,
        CreatedAt = payment.CreatedAt
    };

    return Results.Ok(response);
})
.WithName("GetPaymentStatus")
.WithOpenApi();

app.Run();


