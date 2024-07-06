using Carter;
using FactoryDp.Common.Models;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Endpoints;

public class NotificationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/notification")
            .WithTags("Notification");

        group.MapPost("/", SendNotificationAsync);
    }

    private static async Task<IResult> SendNotificationAsync(NotificationRequestModel request, INotificationFactoryService notificationFactoryService)
    {
        var notification = notificationFactoryService.GetNotificationService(request.NotificationType);
        var result = await notification.SendNotificationAsync(request.Message);
        return Results.Ok(result);
    }
}