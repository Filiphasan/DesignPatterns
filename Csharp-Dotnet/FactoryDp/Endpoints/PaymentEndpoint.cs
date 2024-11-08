using Carter;
using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FactoryDp.Endpoints;

public class PaymentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/payments")
            .WithTags("Payment");
        
        group.MapPost("", HandlePaymentAsync);
    }

    private static async Task<IResult> HandlePaymentAsync([FromBody] PaymentRequestModel request, IPaymentServiceFactory paymentServiceFactory)
    {
        var service = paymentServiceFactory.GetPaymentService(request.BankType);
        var result = await service.HandlePaymentAsync();
        return Results.Ok(result);
    }
}