using Carter;
using ObserverDp.Common.Models;
using ObserverDp.Services.Interfaces;

namespace ObserverDp.Endpoints;

public class NewsletterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/newsletters")
            .WithTags("Newsletter");

        group.MapPost("", AddNewsletterAsync);
    }

    private static async Task<IResult> AddNewsletterAsync(CreateNewsletterRequest model, INewsletterService service)
    {
        await service.AddNewsletterAsync(model);
        return Results.Ok();
    }
}