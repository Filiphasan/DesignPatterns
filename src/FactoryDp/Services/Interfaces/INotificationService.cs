using FactoryDp.Common.Models;

namespace FactoryDp.Services.Interfaces;

public interface INotificationService
{
    Task<NotificationResponseModel> SendNotificationAsync(string message);
}