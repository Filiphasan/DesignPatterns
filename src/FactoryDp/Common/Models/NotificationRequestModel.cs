using FactoryDp.Common.Enums;

namespace FactoryDp.Common.Models;

public class NotificationRequestModel
{
    public NotificationType NotificationType { get; set; }
    public string Message { get; set; } = string.Empty;
}