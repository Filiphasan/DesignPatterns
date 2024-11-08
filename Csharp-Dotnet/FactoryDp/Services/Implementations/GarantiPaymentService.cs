using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class GarantiPaymentService(ILogger<GarantiPaymentService> logger)
    : PaymentBaseService<GarantiPaymentService>(logger), IPaymentService
{
    public async Task<PaymentResponseModel> HandlePaymentAsync()
    {
        logger.LogInformation("GarantiPaymentService started");
        await Task.Delay(1000);
        await HandlePaymentSuccessAsync();
        return new PaymentResponseModel
        {
            Message = "GarantiPaymentService is successful",
        };
    }
}