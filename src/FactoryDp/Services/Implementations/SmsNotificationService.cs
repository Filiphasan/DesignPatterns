using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class SmsNotificationService(ILogger<SmsNotificationService> logger)
    : INotificationService
{
    public async Task<NotificationResponseModel> SendNotificationAsync(string message)
    {
        logger.LogInformation("Sending SMS notification started");
        await Task.Delay(1000);
        logger.LogInformation("Sending SMS notification completed, message: {Message}", message);
        return new NotificationResponseModel
        {
            Message = "Sms notification sent successfully",
        };
    }
}