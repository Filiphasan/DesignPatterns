using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public abstract class PaymentBaseService<T>(
    ILogger<T> logger
)
{
    protected Task HandlePaymentSuccessAsync()
    {
        Task.Delay(1000);
        logger.LogInformation("Payment Success");
        return Task.CompletedTask;
    }
}