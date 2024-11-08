namespace FactoryDp.Services.Implementations;

public abstract class PaymentBaseService<T>(
    ILogger<T> logger
)
{
    protected async Task HandlePaymentSuccessAsync()
    {
        await Task.Delay(1000);
        logger.LogInformation("Payment Success");
    }
}