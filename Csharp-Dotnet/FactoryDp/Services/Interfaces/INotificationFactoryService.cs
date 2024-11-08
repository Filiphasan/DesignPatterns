using FactoryDp.Common.Enums;

namespace FactoryDp.Services.Interfaces;

public interface INotificationFactoryService
{
    INotificationService GetNotificationService(NotificationType notificationType);
}