using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class CallNotificationService(ILogger<CallNotificationService> logger)
    : INotificationService
{
    public async Task<NotificationResponseModel> SendNotificationAsync(string message)
    {
        logger.LogInformation("Sending Call notification started");
        await Task.Delay(1000);
        logger.LogInformation("Sending Call notification completed, message: {Message}", message);
        return new NotificationResponseModel
        {
            Message = "Call notification sent successfully",
        };
    }
}