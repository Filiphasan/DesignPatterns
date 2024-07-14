using BuilderDp.Builders;
using BuilderDp.Common.Models;
using Carter;

namespace BuilderDp.Endpoints;

public class EmailEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/email")
            .WithTags("Email");

        group.MapPost("/send", SendEmailAsync);
    }

    private static async Task<IResult> SendEmailAsync(SendEmailRequest request)
    {
        var emailBuilder = new FluentEmail.Builder()
            .From(request.From)
            .Subject(request.Subject)
            .Body(request.Body, request.Body?.Contains("<html", StringComparison.OrdinalIgnoreCase) ?? false);

        foreach (var to in request.To)
        {
            emailBuilder.To(to);
        }

        foreach (var cc in request.Cc)
        {
            emailBuilder.Cc(cc);
        }

        foreach (var bcc in request.Bcc)
        {
            emailBuilder.Bcc(bcc);
        }

        var result = await emailBuilder
            .Build()
            .SendAsync();
        return Results.Ok(result);
    }
}