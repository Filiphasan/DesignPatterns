using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class AkbankPaymentService(ILogger<AkbankPaymentService> logger)
    : PaymentBaseService<AkbankPaymentService>(logger), IPaymentService
{
    public async Task<PaymentResponseModel> HandlePaymentAsync()
    {
        logger.LogInformation("AkbankPaymentService started");
        await Task.Delay(1000);
        await HandlePaymentSuccessAsync();
        return new PaymentResponseModel
        {
            Message = "AkbankPaymentService is successful",
        };
    }
}