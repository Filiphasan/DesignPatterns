using FactoryDp.Common.Enums;
using FactoryDp.Services.Implementations;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Factories;

public class NotificationFactoryService(IServiceProvider serviceProvider)
    : INotificationFactoryService
{
    public INotificationService GetNotificationService(NotificationType notificationType)
    {
        return notificationType switch
        {
            NotificationType.Sms => serviceProvider.GetRequiredService<SmsNotificationService>(),
            NotificationType.Email => serviceProvider.GetRequiredService<EmailNotificationService>(),
            NotificationType.Whatsapp => serviceProvider.GetRequiredService<WhatsappNotificationService>(),
            NotificationType.Call => serviceProvider.GetRequiredService<CallNotificationService>(),
            _ => throw new InvalidOperationException("Invalid notification type")
        };
    }
}