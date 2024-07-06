using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class YapiKrediPaymentService(ILogger<YapiKrediPaymentService> logger)
    : PaymentBaseService<YapiKrediPaymentService>(logger), IPaymentService
{
    public async Task<PaymentResponseModel> HandlePaymentAsync()
    {
        logger.LogInformation("YapiKrediPaymentService started");
        await Task.Delay(1000);
        await HandlePaymentSuccessAsync();
        return new PaymentResponseModel
        {
            Message = "YapiKrediPaymentService is successful",
        };
    }
}