using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class IsBankasiPaymentService(ILogger<IsBankasiPaymentService> logger)
    : PaymentBaseService<IsBankasiPaymentService>(logger), IPaymentService
{
    public async Task<PaymentResponseModel> HandlePaymentAsync()
    {
        logger.LogInformation("IsBankasiPaymentService started");
        await Task.Delay(1000);
        await HandlePaymentSuccessAsync();
        return new PaymentResponseModel
        {
            Message = "IsBankasiPaymentService is successful",
        };
    }
}