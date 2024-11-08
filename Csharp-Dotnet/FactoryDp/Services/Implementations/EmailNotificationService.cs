using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class EmailNotificationService(ILogger<EmailNotificationService> logger)
    : INotificationService
{
    public async Task<NotificationResponseModel> SendNotificationAsync(string message)
    {
        logger.LogInformation("Sending Email notification started");
        await Task.Delay(1000);
        logger.LogInformation("Sending Email notification completed, message: {Message}", message);
        return new NotificationResponseModel
        {
            Message = "Email notification sent successfully",
        };
    }
}