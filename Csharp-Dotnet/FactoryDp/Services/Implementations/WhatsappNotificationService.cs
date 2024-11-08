using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Implementations;

public class WhatsappNotificationService(ILogger<WhatsappNotificationService> logger)
    : INotificationService
{
    public async Task<NotificationResponseModel> SendNotificationAsync(string message)
    {
        logger.LogInformation("Sending Whatsapp notification started");
        await Task.Delay(1000);
        logger.LogInformation("Sending Whatsapp notification completed, message: {Message}", message);
        return new NotificationResponseModel
        {
            Message = "Whatsapp notification sent successfully",
        };
    }
}